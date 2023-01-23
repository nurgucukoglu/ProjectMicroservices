using Ecommerce.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectMicroservices.Services.Discount.Services
{
    public interface IDiscountService
    {
        //intf.de async Task.. diye tanımlanır.
        Task<ResponseDto<List<Models.Discount>>> GetAll();
        Task<ResponseDto<Models.Discount>> GetById(int id);
        Task<ResponseDto<NoContent>> Save(Models.Discount discount);
        Task<ResponseDto<NoContent>> Update(Models.Discount discount);
        Task<ResponseDto<NoContent>> Delete(int id);
        Task<ResponseDto<List<Models.Discount>>> GetByCodeUserId(string code, string userId);
    }
}
