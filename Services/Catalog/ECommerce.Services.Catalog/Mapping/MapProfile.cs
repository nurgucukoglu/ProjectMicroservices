using AutoMapper;
using ECommerce.Services.Catalog.DTOs;
using ECommerce.Services.Catalog.Models;

namespace ECommerce.Services.Catalog.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile() 
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();


            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();

            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
