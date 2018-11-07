using Microsoft.AspNetCore.Mvc;

namespace RCommerce.Module.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        public IActionResult TestAC()
        {
            return Ok();
        }
    }
}