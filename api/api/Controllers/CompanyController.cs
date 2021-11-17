using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        // Get
        [HttpGet]
        public string Get()
        {
            return "new company";
        }
    }
}