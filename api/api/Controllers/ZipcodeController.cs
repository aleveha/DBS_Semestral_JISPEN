using System.Collections.Generic;
using api.App;
using api.Core.Managers;
using api.Models;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    [ApiController]
    [Route("api/zipcode")]
    public class ZipcodeController : Controller {
        private readonly ITemplateManager _templateManager;

        public ZipcodeController(ApplicationContext context) {
            _templateManager = new TemplateManager(context);
        }

        [HttpGet]
        [Route("/zipcode/get-all")]
        public List<ZipCode> GetAll() {
            return _templateManager.GetAllZipCodes();
        }
    }
}
