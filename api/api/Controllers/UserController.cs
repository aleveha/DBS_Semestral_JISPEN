using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // GET
        [HttpGet]
        public ActionResult<User> Get()
        {
            User user = new User {Email = "email", PhoneNumber = 1234, RecoveryCode = "recovery code"};
            return Ok(user);
        }
    }
}