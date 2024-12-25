using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using UdemyCourseApi.Data;
using UdemyCourseApi.ExceptionHandler;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;
using UdemyCourseApi.Models.Enums;
using UdemyCourseApi.Repositories;
using UdemyCourseApi.Service;
namespace UdemyCourseApi.Repositories
{
    public class ProductRepository(IWebHostEnvironment webHostEnvironment, IMapper mapper, ProductHandlerDb productHandler, IImageProcessingService imageProcessingService,


        IMemoryCache memoryCache) : IProductRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
        private readonly IMapper _mapper = mapper;
        private readonly ProductHandlerDb _productHandler = productHandler;
        private readonly IImageProcessingService _imageProcessingService = imageProcessingService;
        public IMemoryCache MemoryCache { get; } = memoryCache;

        public const string DropDownCacheKey = "DropdownData";

        public async Task<Result<ProductResponseDto>> AddProductAsync(ProductRequestDto productRequestDto)
        {
            using var transaction = await _productHandler.Database.BeginTransactionAsync();
            try
            {
                var product = _mapper.Map<Product>(productRequestDto);
                if (productRequestDto.Image == null || productRequestDto.Image.Length == 0)
                    throw new Exception("Invalid file");
                var primaryImagePath = await _imageProcessingService.SaveImageAsync(productRequestDto.Image);
                product.ImageUrl = primaryImagePath;
                product.Id = Guid.NewGuid();
                product.CreatedDate = DateTime.UtcNow;
                var productImages = new List<ProductImages>();
                if (productRequestDto.Images != null)
                {
                    foreach (var image in productRequestDto.Images)
                    {
                        var imagePath = await _imageProcessingService.SaveImageAsync(image);
                        productImages.Add(new ProductImages
                        {
                            Id = Guid.NewGuid(),
                            ImageUrl = imagePath,
                            ProductId = product.Id
                        });
                    }
                }
                product.Images = productImages;
                var sizes = productRequestDto.Sizes != null
                          ? await _productHandler.ProductSizes
                              .Where(size => productRequestDto.Sizes.Contains(size.Id))
                              .ToListAsync()
                          : [];
                if (sizes.Count == 0)
                    throw new Exception("Invalid sizes provided.");
                var validSubcategories = productRequestDto.SubcategoryIds != null
                                         ? await _productHandler.SubCategories
                                             .Where(subcategory => productRequestDto.SubcategoryIds.Contains(subcategory.Id))
                                             .ToListAsync()
                                         : [];

                if (validSubcategories.Count != productRequestDto.SubcategoryIds?.Count)
                {
                    throw new Exception("One or more subcategories provided are invalid.");
                }
                var productSubcategory = validSubcategories.Select
                    (subcategory => new ProductSubcategory
                    {

                        Id = Guid.NewGuid(),
                        ProductId = product.Id,
                        SubcategoryId = subcategory.Id
                    }).ToList();

                product.Sizes = sizes;
                product.ProductSubcategories = productSubcategory;
                product.Description = productRequestDto.Description ?? "Default description";
                await _productHandler.Products.AddAsync(product);
                await _productHandler.SaveChangesAsync();
                await transaction.CommitAsync();
                var productResponseDto = _mapper.Map<ProductResponseDto>(product);
                return Result<ProductResponseDto>.Success(productResponseDto);

            }
            catch (ProductException ex)
            {
                await transaction.RollbackAsync();
                var errorResponse = new ProductResponseDto
                {
                    Error = ex.Message
                };
                return Result<ProductResponseDto>.Failure(errorResponse.Error);

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                var errorResponse = new ProductResponseDto
                {
                    Error = $"An unexpected error occurred: {ex.Message}"
                };
                return Result<ProductResponseDto>.Failure(errorResponse.Error);
            }

        }

        public async Task<Result<ProductResponseDto>> DeleteProductAsync(Guid id)
        {
            var product = await _productHandler.Products
                    .Include(p => p.Images)
                    .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                var errorResponse = new ProductResponseDto
                {
                    Error = "Product does not found"
                };
                return Result<ProductResponseDto>.Failure(errorResponse.Error);
            }

            _productHandler.Remove(product);
            if (product.Images != null && product.Images.Count != 0)
            {
                foreach (var image in product.Images)
                {
                    var imageUrl = image.ImageUrl?.TrimStart('/') ?? string.Empty;
                    if (imageUrl.StartsWith("images/"))
                    {
                        imageUrl = imageUrl["images/".Length..];
                    }
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", imageUrl);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
            }


            await _productHandler.SaveChangesAsync();
            return Result<ProductResponseDto>.Success(new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name
            });

        }

        public async Task<IEnumerable<Result<ProductResponseDto>>> GetAllLatestProductAsync()
        {
            try
            {
                var products = await _productHandler.Products
                                                      .OrderByDescending(p => p.CreatedDate)
                                                      .ToListAsync();
                if (products == null || products.Count == 0)
                {
                    return new List<Result<ProductResponseDto>>
            {
                Result<ProductResponseDto>.Failure("No products found.")
            };
                }
                var result = products.Select(product =>
                {
                    var productResponseDto = new ProductResponseDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description
                    };

                    return Result<ProductResponseDto>.Success(productResponseDto);
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., logging)
                return new List<Result<ProductResponseDto>>
        {
            Result<ProductResponseDto>.Failure($"An error occurred: {ex.Message}")
        };
            }
        }

        public async Task<IEnumerable<Result<ProductResponseDto>>> GetAllProductAsync()
        {
            try
            {
                var products = await _productHandler.Products
                                 .Include(p => p.Images)
                                 .Include(p => p.Sizes)
                                 .Select(p => new ProductResponseDto
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     Description = p.Description,
                                     Price = p.Price,
                                     ImageUrls = p.Images
                                         .Select(i => i.ImageUrl ?? string.Empty) // Handle nullable strings
                                         .ToList(),
                                     Sizes = p.Sizes.Select(s => s.Id).ToList(), // Get only the Ids of the sizes
                                 })
                                 .ToListAsync();
                var productDtos = _mapper.Map<List<ProductResponseDto>>(products);
                var result = productDtos.Select(dto => Result<ProductResponseDto>.Success(dto)).ToList();

                return result;
            }
            catch (ProductException ex)
            {
                // Handle specific product-related exceptions and return failure result
                var errorResponse = new ProductResponseDto
                {
                    Error = ex.Message
                };
                return new List<Result<ProductResponseDto>>
        {
            Result<ProductResponseDto>.Failure(errorResponse.Error)
        };
            }
            catch (Exception ex)
            {
                // Handle general exceptions and return failure result
                var errorResponse = new ProductResponseDto
                {
                    Error = $"An unexpected error occurred: {ex.Message}"
                };
                return new List<Result<ProductResponseDto>>
            {
                Result<ProductResponseDto>.Failure(errorResponse.Error)
            };
            }
        }

        public async Task<Result<ProductResponseDto>> GetProductById(Guid productId)
        {
            try
            {

                var product = await _productHandler.Products
                .Include(p => p.Images)
                .Include(p => p.Sizes)
                .FirstOrDefaultAsync(p => p.Id == productId);
                if (product == null)
                {
                    var errorResponse = new ProductResponseDto
                    {
                        Error = "Product does not found"
                    };
                    return Result<ProductResponseDto>.Failure(errorResponse.Error);
                }
                var productResponseDto = _mapper.Map<ProductResponseDto>(product);
                return Result<ProductResponseDto>.Success(productResponseDto);
            }
            catch (ProductException ex)
            {
                var errorResponse = new ProductResponseDto
                {
                    Error = ex.Message
                };
                return Result<ProductResponseDto>.Failure(errorResponse.Error);

            }
            catch (Exception ex)
            {
                // Handle general exceptions and return an error response
                var errorResponse = new ProductResponseDto
                {
                    Error = $"An unexpected error occurred: {ex.Message}"
                };
                return Result<ProductResponseDto>.Failure(errorResponse.Error);
            }
        }

        public async Task<Result<ProductResponseDto>> UpdateProduct(Guid id, UpdateProductDto productRequestDto)
        {
            try
            {
                var product = await _productHandler.Products
                  .Include(p => p.Sizes)
                   .FirstOrDefaultAsync(p => p.Id == id);
                if (product == null)
                {
                    var errorResponse1 = new ProductResponseDto
                    {
                        Error = "Product does not found"
                    };
                    return Result<ProductResponseDto>.Failure(errorResponse1.Error);
                }
                var sizes = await _productHandler.ProductSizes
                   .Where(size => productRequestDto.Sizes.Contains(size.Id))
                   .ToListAsync();
                product.Price = productRequestDto.Price ?? 0m;
                product.Stock = productRequestDto.Stock;
                product.UpdatedDate = DateTime.Now;
                product.Sizes = sizes;
                product.Description = productRequestDto.Description ?? string.Empty;
                product.IsAvailable = productRequestDto.IsAvailable ?? false;
                product.Name = productRequestDto.Name ?? "";
                product.UserId = productRequestDto.UserId;
                await _productHandler.SaveChangesAsync();
                var updatedProduct = _mapper.Map<ProductResponseDto>(product);
                return Result<ProductResponseDto>.Success(updatedProduct);
            

            }
            catch (ProductException ex)
            {
                var errorResponse = new ProductResponseDto
                {
                    Error = ex.Message
                };
                return Result<ProductResponseDto>.Failure(errorResponse.Error);

            }
            catch (Exception ex)
            {
                var errorResponse = new ProductResponseDto
                {
                    Error = $"An unexpected error occurred: {ex.Message}"
                };
                return Result<ProductResponseDto>.Failure(errorResponse.Error);
            }

        }

        public async Task<GetAllDropDownData> GetDropdownData()
        {
            if (!MemoryCache.TryGetValue(DropDownCacheKey, out GetAllDropDownData? dropdownData))
            {
                // Data not in cache, fetch from database
                var sizes = Enum.GetValues(typeof(Sizes))
                    .Cast<Sizes>()
                    .Select(c => new DropDownItemDtocs
                    {
                        Name = c.ToString(),
                    })
                    .ToList();

                var subcategories = await _productHandler.SubCategories
                    .Select(sc => new DropDownItemDtocs { Id = sc.Id, Name = sc.Name })
                    .ToListAsync();

                var cities = Enum.GetValues(typeof(City))
                     .Cast<City>()
                     .Select(c => new DropDownItemDtocs
                     {

                         Name = c.ToString()
                     })
                     .ToList();

                var categories = await _productHandler.Categories
                    .Select(cat => new DropDownItemDtocs { Id = cat.Id, Name = cat.Name })
                    .ToListAsync();

                dropdownData = new GetAllDropDownData
                {
                    Sizes = sizes,
                    Subcategories = subcategories,
                    Cities = cities,
                    Categories = categories
                };

                // Set data in cache with expiration
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(1)) // Sliding expiration
                    .SetAbsoluteExpiration(TimeSpan.FromHours(6)); // Absolute expiration

                MemoryCache.Set(DropDownCacheKey, dropdownData, cacheEntryOptions);
            }

            return dropdownData!;
        }

        public async Task<Result<ProductResponseDto>> AdminApproval(Guid productId)
        {
            var product = await _productHandler.Products
                .FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                var errorResponse = new ProductResponseDto
                {
                    Error = "Product does not found"
                };
                return Result<ProductResponseDto>.Failure(errorResponse.Error);
            }
            product.ProductStatus = ProductStatus.AVAILABLE;
            await _productHandler.SaveChangesAsync();
            var productResponseDto = _mapper.Map<ProductResponseDto>(product);
            return Result<ProductResponseDto>.Success(productResponseDto);




        }

        public async Task<Result<List<ProductCategoryResponseDto>>> GetProductAccordingToCategory(Guid categoryId)
        {
            try
            {
                var products = await _productHandler.Products
                    .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new ProductCategoryResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description
                })
                .ToListAsync();

                if (products.Count == 0)
                {
                    return Result<List<ProductCategoryResponseDto>>.Failure("No products found");
                }

                var result = Result<List<ProductCategoryResponseDto>>.Success(products);
                return result;
            }
            catch (Exception ex)
            {
                return Result<List<ProductCategoryResponseDto>>.Failure($"An unexpected error occurred: {ex.Message}");
            }

        }

        public async Task<Result<List<ProductCategoryResponseDto>>> GetProductAccordingToSubCategory(Guid SubCategoryId)
        {
            try
            {
                var products = await _productHandler.Products
                .Include(p => p.ProductSubcategories)
                .Where(p => p.ProductSubcategories != null && p.ProductSubcategories.Any(ps => ps.SubcategoryId == SubCategoryId))
                 .Select(p => new ProductCategoryResponseDto
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Description = p.Description
                 })
                .ToListAsync();

                if (products.Count == 0)
                {
                    return Result<List<ProductCategoryResponseDto>>.Failure("No products found");
                }
                var result = Result<List<ProductCategoryResponseDto>>.Success(products);
                return result;
            }
            catch(Exception ex)
            {

                return Result<List<ProductCategoryResponseDto>>.Failure($"An unexpected error occurred: {ex.Message}");
            }
           
        }
    }

}
