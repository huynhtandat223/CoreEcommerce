using Microsoft.AspNetCore.Mvc;

namespace RCommerce.Module.Authentication.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
