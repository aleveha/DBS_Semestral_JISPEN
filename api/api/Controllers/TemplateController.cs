using System.Collections.Generic;
using api.App;
using api.Core.Managers;
using api.Models;
using api.Persistence;
using Microsoft.AspNetCore.Http;
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
        [Route("/template/getAllTemplates")]
        public ActionResult<List<Template>> GetAll(long userId) {
            return Ok(_templateManager.GetAllTemplates(userId));
        }

        [HttpGet]
        [Route("/template/getTemplate")]
        public ActionResult<List<Template>> Get(long id) {
            Template result = _templateManager.Get(id);
            return result == null ? StatusCode(StatusCodes.Status400BadRequest) : Ok(result);
        }

        [HttpPost]
        [Route("/template/addTemplate")]
        public ActionResult<Template> Add(Template template) {
            return Ok(_templateManager.Add(template));
        }

        [HttpPost]
        [Route("/template/updateTemplate")]
        public ActionResult<Template> Update(Template template) {
            return Ok(_templateManager.Update(template));
        }

        [HttpDelete]
        [Route("/template/deleteTemplate")]
        public ActionResult<bool> Delete(Template template) {
            return Ok(_templateManager.Delete(template));
        }
    }
}
