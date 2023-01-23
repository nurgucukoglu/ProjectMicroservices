using Dapper;
using Ecommerce.Shared.Dtos;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ProjectMicroservices.Services.Discount.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMicroservices.Services.Discount.Services
{

   //Dapper bir orm.dir.SQl queryleriyle çalışır.
    public class DiscountService : IDiscountService
    {

        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql")); //key
        }

        public async Task<ResponseDto<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from discount where Id=@id", new {id=id });
            return status > 0 ? ResponseDto<NoContent>.Success(204) : ResponseDto<NoContent>.Fail("silineceke değer bulunamadı", 404); //silinen eleman varsa
        }

        public async Task<ResponseDto<List<Models.Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("select * from discount");
            return ResponseDto<List<Models.Discount>>.Success(discounts.ToList(), 200);
        }

        public Task<ResponseDto<List<Models.Discount>>> GetByCodeUserId(string code, string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseDto<Models.Discount>> GetById(int id) //tek veri dönecek
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select * from discount where Id=@id", new { id = id })).SingleOrDefault();
            return ResponseDto<Models.Discount>.Success(discount, 200);
        }

        public async Task<ResponseDto<NoContent>> Save(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("insert into discount (userid,rate,code) values (@UserId,@Rate,@Code)", discount);
            if(status>0)
            {
                return ResponseDto<NoContent>.Success(204);

            }
            return ResponseDto<NoContent>.Fail("bir hata oluştu",500);
        }

        public async Task<ResponseDto<NoContent>> Update(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userid=@UserId,rate=@Rate,code=@Code where Id=@id)", discount);
            if (status > 0)
            {
                return ResponseDto<NoContent>.Success(204);

            }
            return ResponseDto<NoContent>.Fail("bir hata oluştu", 500);
        }
    }
}
