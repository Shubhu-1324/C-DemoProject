using AutoMapper;
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
}
