using Ecommerce.Shared.Dtos;
using ECommerce.Services.Catalog.DTOs;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Services.Catalog.Services
{
    public interface IProductService
    {
        Task<ResponseDto<List<ProductDto>>> GetAllAsync();
        Task<ResponseDto<ProductDto>> GetByIdAsync(string id);
        Task<ResponseDto<ProductDto>> CreateProductDto(CreateProductDto createProductDto);
        Task<ResponseDto<NoContent>> UpdateAsync(UpdateProductDto  updateProductDto);
        Task<ResponseDto<NoContent>> DeleteAsync(string id);


    }
}
