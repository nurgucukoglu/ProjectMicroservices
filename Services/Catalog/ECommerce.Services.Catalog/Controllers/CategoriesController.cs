using Ecommerce.Shared.ControllerBases;
using ECommerce.Services.Catalog.DTOs;
using ECommerce.Services.Catalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task< IActionResult> GetAll() 
        { 
            var response= await _categoryService.GetAllAsync();
            return CreateResultInstance(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var response= await _categoryService.GetByIdAsync(id);
            return CreateResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var response= await _categoryService.CreateAsync(categoryDto);
            return CreateResultInstance(response);
        }
    }
}
