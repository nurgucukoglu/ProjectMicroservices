using Ecommerce.Shared.Dtos;
using ProjectMicroservices.Services.Basket.Dtos;
using System.Threading.Tasks;

namespace ProjectMicroservices.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<ResponseDto<BasketDto>> GetBasket(string userId);
        Task<ResponseDto<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<ResponseDto<bool>> Delete(string userId);


    }
}
