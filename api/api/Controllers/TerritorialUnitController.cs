using System.Collections.Generic;
using api.App;
using api.Core.Managers;
using api.Models;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    [ApiController]
    [Route("api/territorial-unit")]
    public class TerritorialUnitController {
        private readonly ITemplateManager _templateManager;

        public TerritorialUnitController(ApplicationContext context) {
            _templateManager = new TemplateManager(context);
        }

        [HttpGet]
        [Route("/territorial-unit/get-all")]
        public List<TerritorialUnit> GetAll() {
            return _templateManager.GetAllTerritorialUnits();
        }
    }
}
