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
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAllAsync();
            return CreateResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var response = await _productService.GetByIdAsync(id);
            return CreateResultInstance(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            var response = await _productService.CreateProductDto(createProductDto);
            return CreateResultInstance(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var response = await _productService.UpdateAsync(updateProductDto);
            return CreateResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _productService.DeleteAsync(id);
            return CreateResultInstance(response);
        }
    }
}
