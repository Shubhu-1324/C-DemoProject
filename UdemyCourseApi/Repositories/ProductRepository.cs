using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.IO;
using UdemyCourseApi.Data;
using UdemyCourseApi.ExceptionHandler;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;
using UdemyCourseApi.Repositories;
using UdemyCourseApi.Service;

public class ProductRepository:IProductRepository
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMapper _mapper;
    private readonly ProductHandlerDb _productHandler;
    private readonly IImageProcessingService _imageProcessingService;

    public ProductRepository(IWebHostEnvironment webHostEnvironment,IMapper mapper,ProductHandlerDb productHandler,IImageProcessingService imageProcessingService)
    {
        _webHostEnvironment = webHostEnvironment;
        _mapper=mapper;
        _productHandler=productHandler;
        _imageProcessingService = imageProcessingService;
    }
    
    public async Task<Result<ProductResponseDto>> AddProductAsync(ProductRequestDto productRequestDto)
    {
        try
        {
            var product = _mapper.Map<Product>(productRequestDto);
            if (productRequestDto.Image == null || productRequestDto.Image.Length == 0)
                throw new Exception("Invalid file");

            var primaryImagePath = await _imageProcessingService.SaveImageAsync(productRequestDto.Image);
             product = new Product
            {
                 Name = productRequestDto.Name,
                 ImageUrl=primaryImagePath
            };

            var entities = new List<ProductImages>();
            foreach(var image in productRequestDto.Images) {
                var imagePath = await _imageProcessingService.SaveImageAsync(image);
                entities.Add(new ProductImages {
                    
                    Id=new Guid(),
                    ImageUrl = imagePath 
                });
            }

            var sizes = await _productHandler.ProductSizes
                .Where(size => productRequestDto.Sizes.Contains(size.Id))
                .ToListAsync();
            product.Sizes = sizes;
            product.Id = Guid.NewGuid();
            product.CreatedDate = DateTime.UtcNow;

            await _productHandler.Products.AddAsync(product);
            await _productHandler.SaveChangesAsync();

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
            var errorResponse = new ProductResponseDto
            {
                Error = $"An unexpected error occurred: {ex.Message}"
            };
            return Result<ProductResponseDto>.Failure(errorResponse.Error);
        }

    }

    public async Task<Result<ProductResponseDto>> DeleteProductAsync(Guid id)
    {
        var product =  await _productHandler.Products
                .Include(p => p.Images)  
                .FirstOrDefaultAsync(p => p.Id == id);
        if (product==null)
        {
            var errorResponse = new ProductResponseDto
            {
                Error = "Product does not found"
            };
            return Result<ProductResponseDto>.Failure(errorResponse.Error);
        }

        _productHandler.Remove(product);
        if (product.Images != null && product.Images.Any())
        {
            foreach (var image in product.Images)
            {
                var imageUrl = image.ImageUrl.TrimStart('/');
                if (imageUrl.StartsWith("images/"))
                {
                    imageUrl = imageUrl.Substring("images/".Length);  
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
            if (products == null || !products.Any())
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
                            ImageUrls = p.Images.Select(i => i.ImageUrl).ToList(),
                            Sizes = p.Sizes.Select(s => s.Id).ToList(),  // Get only the Ids of the sizes
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
            .Include(p=>p.Sizes)
            .FirstOrDefaultAsync(p => p.Id == productId);
            if (product==null)
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

    public async Task<Result<ProductResponseDto>> UpdateProduct(Guid id, UpdateProductDto productRequestDto )
    {
        try
        {
            var product = await _productHandler.Products
               .Include(p => p.Images)
               .FirstOrDefaultAsync(p => p.Id == id);
            if (product==null)
            {
                var errorResponse1 = new ProductResponseDto
                {
                    Error = "Product does not found"
                };
                return Result<ProductResponseDto>.Failure(errorResponse1.Error);
            }
            product.Price = productRequestDto.Price;
            product.Stock = productRequestDto.Stock;
            product.UpdatedDate=DateTime.Now;
            product.Description= productRequestDto.Description;
            product.IsAvailable= productRequestDto.IsAvailable;
            product.Name= productRequestDto.Name;
            product.UserId= productRequestDto.UserId;
            if (productRequestDto.Images!=null && productRequestDto.Images.Any())
            {
                foreach (var image in product.Images)
                {
                    var imageUrl = image.ImageUrl.TrimStart('/');
                    if (imageUrl.StartsWith("images/"))
                    {
                        imageUrl = imageUrl.Substring("images/".Length);
                    }
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", imageUrl);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
                var webhost = _webHostEnvironment.WebRootPath;
                var imagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }
                var imageEntities = new List<ProductImages>();
                foreach (var imageFile in productRequestDto.Images)
                {
                    var imageName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                    var filePath = Path.Combine(imagesFolder, imageName);

                    // Save the file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    imageEntities.Add(new ProductImages
                    {
                        Id = Guid.NewGuid(),
                        ImageUrl = $"/images/{imageName}",
                        ProductId = id
                    }); ;

                }
                product.Images = imageEntities;



                await _productHandler.SaveChangesAsync();

                var updatedProduct = _mapper.Map<ProductResponseDto>(product);
                return Result<ProductResponseDto>.Success(updatedProduct);

            }
            var errorResponse = new ProductResponseDto
            {
                Error = "Product does not found"
            };
            return Result<ProductResponseDto>.Failure(errorResponse.Error);

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
}
