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
        [Route("/template/get-all")]
        public ActionResult<List<Template>> GetAll(long userId) {
            return Ok(_templateManager.GetAllTemplates(userId));
        }

        [HttpGet]
        [Route("/template/get")]
        public ActionResult<Template> Get(long id) {
            Template result = _templateManager.Get(id);
            return result == null ? StatusCode(StatusCodes.Status400BadRequest) : Ok(result);
        }

        [HttpPost]
        [Route("/template/add")]
        public ActionResult<Template> Add(Template template) {
            Template result = _templateManager.Add(template);
            return result == null ? StatusCode(StatusCodes.Status400BadRequest) : Ok(result);
        }

        [HttpDelete]
        [Route("/template/delete")]
        public ActionResult<bool> Delete(long id) {
            return Ok(_templateManager.Delete(id));
        }
    }
}
