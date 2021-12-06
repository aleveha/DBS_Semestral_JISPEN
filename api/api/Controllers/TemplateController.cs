using api.App;
using api.Core.Managers;
using api.Models;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    [ApiController]
    [Route("api/template")]
    public class TemplateController : Controller {
        private readonly ITemplateManager _templateManager;

        public TemplateController(ApplicationContext context) {
            _templateManager = new TemplateManager(context);
        }

        [HttpGet]
        public ActionResult<Template> GetAllTemplates(string email) {
            return Ok(_templateManager.GetAllTemplates(email));
        }
    }
}
