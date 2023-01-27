using Ecommerce.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMicroservices.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : CustomBaseController
    {

        [HttpPost]
        public IActionResult ReceivePayment()
        { 
            return CreateResultInstance(ResponseDto<NoContentResult),200);
        }
    }
}
