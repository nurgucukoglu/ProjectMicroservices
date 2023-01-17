using Ecommerce.Shared.Dtos;
using ECommerce.Services.Catalog.DTOs;
using Ecommerce.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<ResponseDto<List<CategoryDto>>> GetAllAsync(); //olabildğince modellerden kaçıp dto.ları kullanıyoruz.
        Task<ResponseDto<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<ResponseDto<CategoryDto>> GetByIdAsync(string id);
    }
}
