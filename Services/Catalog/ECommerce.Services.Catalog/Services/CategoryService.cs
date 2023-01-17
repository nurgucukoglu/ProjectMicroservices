using AutoMapper;
using ECommerce.Services.Catalog.DTOs;
using ECommerce.Services.Catalog.Models;
using ECommerce.Services.Catalog.Settings;
using MongoDB.Driver;
using Ecommerce.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databasettings) //ctor
        {
            var client=new MongoClient(databasettings.ConnectionString);
            var database = client.GetDatabase(databasettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databasettings.CategoryCollectionName);
            _mapper= mapper;
        }

        //ekleme iççin ayrı bir dto yazmış ezber olmasın diye.
        public async Task<ResponseDto<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            var category= _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(category);
            return ResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<ResponseDto<List<CategoryDto>>> GetAllAsync()
        {
            var categories= await _categoryCollection.Find(category => true).ToListAsync();
            return ResponseDto<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<ResponseDto<CategoryDto>> GetByIdAsync(string id) //modelde id.yi string tanımlamıştık.
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if(category== null)
            {
                return ResponseDto<CategoryDto>.Fail("kategori bulunamadı.", 404);
            }
            else
            {
                return ResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
            }
        }
    }
}
