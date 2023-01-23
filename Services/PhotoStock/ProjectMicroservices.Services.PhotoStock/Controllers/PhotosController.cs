using Ecommerce.Shared.ControllerBases;
using Ecommerce.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectMicroservices.Services.PhotoStock.Dtos;
using System.IO;
using System.Threading.Tasks;

namespace ProjectMicroservices.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile formFile)
        {
            if (formFile != null && formFile.Length>0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", formFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await formFile.CopyToAsync(stream);

                var returnPath = "photos/"+ formFile.FileName;

                PhotoDto photoDto = new()
                {
                    URL = returnPath, //dosyanın yeni bilgisi returnoathde
                };

                return CreateResultInstance(ResponseDto<PhotoDto>.Success(photoDto, 200));
            }
            return CreateResultInstance(ResponseDto<PhotoDto>.Fail("hata oluştu", 400));
        }
    }
}
