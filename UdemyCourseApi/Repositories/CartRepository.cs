using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UdemyCourseApi.Data;
using UdemyCourseApi.ExceptionHandler;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;

namespace UdemyCourseApi.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IMapper _mapper;
        private readonly ProductHandlerDb _productHandlerDb;
        private readonly IProductRepository _productRepository;

        public CartRepository(IMapper mapper, ProductHandlerDb productHandlerDb,IProductRepository productRepository) {
             _mapper=mapper;
            _productHandlerDb=productHandlerDb;
            _productRepository=productRepository;
        }
        public async Task<Result<CartResponseDto>> AddProductAsync(CartHandlerRequestDto cartHandlerRequestDto)
        {
            try
            {
                var cart = _mapper.Map<CartHandler>(cartHandlerRequestDto);
                var product = await _productHandlerDb.Products.FirstOrDefaultAsync(p => p.Id==cartHandlerRequestDto.ProductId);
                if (product == null)
                {
                    var errorResponse = new CartResponseDto
                    {
                        Error = "Product does not found"
                    };
                    return Result<CartResponseDto>.Failure(errorResponse.Error);
                }
                if(product.Stock <cartHandlerRequestDto.Quantity)
                {
                    var errorResponse = new CartResponseDto
                    {
                        Error = "Quantity is to much"
                    };
                    return Result<CartResponseDto>.Failure(errorResponse.Error);
                }

                product.Stock=product.Stock-cartHandlerRequestDto.Quantity;
                decimal productPrice = product.Price;
                
                var productDto=_mapper.Map<UpdateProductDto>(product);
                

                await _productRepository.UpdateProduct(cartHandlerRequestDto.ProductId, productDto);



                if (cart == null)
                {

                    var errorResponse = new CartResponseDto
                    {
                        Error = "cart does not found"
                    };
                    return Result<CartResponseDto>.Failure(errorResponse.Error);
                }
                cart.AddedAt = DateTime.Now;
                cart.Id=new Guid();
                cart.TotalPrice = productPrice*cartHandlerRequestDto.Quantity;

                await _productHandlerDb.CartHandlers.AddAsync(cart);
                await _productHandlerDb.SaveChangesAsync(); 
                var responseDto = _mapper.Map<CartResponseDto>(cart);
                return  Result<CartResponseDto>.Success(responseDto);

            }
            catch (Exception ex)
            {
                // Handle general exceptions and return an error response
                var errorResponse = new CartResponseDto
                {
                    Error = $"An unexpected error occurred: {ex.Message}"
                };
                return Result<CartResponseDto>.Failure(errorResponse.Error);
            }
        }
    }
}
