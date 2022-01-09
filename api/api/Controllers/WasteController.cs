using System.Collections.Generic;
using api.App;
using api.Core.Managers;
using api.Models;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    [ApiController]
    [Route("api/waste")]
    public class WasteController {
        private readonly ITemplateManager _templateManager;

        public WasteController(ApplicationContext context) {
            _templateManager = new TemplateManager(context);
        }

        [HttpGet]
        [Route("/waste/get-all")]
        public List<Waste> GetAll() {
            return _templateManager.GetAllWastes();
        }
    }
}
