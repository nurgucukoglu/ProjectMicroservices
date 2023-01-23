using Ecommerce.Shared.Dtos;
using ProjectMicroservices.Services.Basket.Dtos;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectMicroservices.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<ResponseDto<bool>> Delete(string userId)
        {
            var status= await _redisService.GetDb().KeyDeleteAsync(userId);
            return status ? ResponseDto<bool>.Success(204) : ResponseDto<bool>.Fail("silinecek değer bulunamadı", 404);
        }

        public async Task<ResponseDto<BasketDto>> GetBasket(string userId)
        {
            var existBasket= await _redisService.GetDb().StringGetAsync(userId);
            if(string.IsNullOrEmpty(existBasket))
            {
                return ResponseDto<BasketDto>.Fail("sepet bulunamadı", 404);
            }
            return ResponseDto<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
        }

        public async Task<ResponseDto<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
            return status ? ResponseDto<bool>.Success(204) : ResponseDto<bool>.Fail("bir hata oluştu", 500);
        }
    }
}
