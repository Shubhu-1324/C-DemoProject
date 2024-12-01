using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using UdemyCourseApi.Data;
using UdemyCourseApi.ExceptionHandler;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;
using UdemyCourseApi.Repositories;

public class ProductRepository:IProductRepository
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMapper _mapper;
    private readonly ProductHandlerDb _productHandler;

    public ProductRepository(IWebHostEnvironment webHostEnvironment,IMapper mapper,ProductHandlerDb productHandler)
    {
        _webHostEnvironment = webHostEnvironment;
        _mapper=mapper;
        _productHandler=productHandler;
    }
    
    public async Task<Result<ProductResponseDto>> AddProductAsync(ProductRequestDto productRequestDto)
    {
        try
        {
            var product = _mapper.Map<Product>(productRequestDto);
            if (productRequestDto.Image == null || productRequestDto.Image.Length == 0)
                throw new Exception("Invalid file");
            var webhost = _webHostEnvironment.WebRootPath;
            var imagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            var imageName = $"{Guid.NewGuid()}{Path.GetExtension(productRequestDto.Image.FileName)}";

            // Save the file (example logic)
            var filePath = Path.Combine(imagesFolder, imageName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await productRequestDto.Image.CopyToAsync(stream);
            }
            product.ImageUrl = $"/images/{imageName}";
            product.Id=new Guid();
            product.CreatedDate= DateTime.Now;
            await _productHandler.Products.AddAsync(product);
            await _productHandler.SaveChangesAsync();

            var productResponseDto = _mapper.Map<ProductResponseDto>(product);
            return Result<ProductResponseDto>.Success(productResponseDto);
        }
        catch(ProductException ex)
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

    public async Task<Result<ProductResponseDto>> DeleteProductAsync(Guid id)
    {
        var product = await _productHandler.Products.FirstOrDefaultAsync(p => p.Id==id);
        if(product==null)
        {
            var errorResponse = new ProductResponseDto
            {
                Error = "Product does not found"
            };
            return Result<ProductResponseDto>.Failure(errorResponse.Error);
        }

        _productHandler.Remove(product);
        if (!string.IsNullOrEmpty(product.ImageUrl))
        {
            var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", product.ImageUrl.TrimStart('/'));
            if (File.Exists(oldImagePath))
            {
                File.Delete(oldImagePath);
            }
        }
        await _productHandler.SaveChangesAsync();
        return Result<ProductResponseDto>.Success(new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name
        });

    }

    public async Task<IEnumerable<Result<ProductResponseDto>>> GetAllProductAsync()
    {
        try
        {
            var products = await _productHandler.Products
                .ProjectTo<ProductResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            // Wrap each ProductResponseDto in a Result<ProductResponseDto>
            var result = products.Select(product => Result<ProductResponseDto>.Success(product)).ToList();

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
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id==productId);
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
            var product = await _productHandler.Products.FirstOrDefaultAsync(p=> p.Id==id);
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

            if (productRequestDto.Image != null && productRequestDto.Image.Length > 0)
            {
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", product.ImageUrl.TrimStart('/'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }
                var webhost = _webHostEnvironment.WebRootPath;
                var imagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                var imageName = $"{Guid.NewGuid()}{Path.GetExtension(productRequestDto.Image.FileName)}";

                // Save the file (example logic)
                var filePath = Path.Combine(imagesFolder, imageName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await productRequestDto.Image.CopyToAsync(stream);
                }
                product.ImageUrl = $"/images/{imageName}";

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
