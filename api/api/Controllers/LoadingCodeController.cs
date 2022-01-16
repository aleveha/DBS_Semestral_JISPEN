using System.Collections.Generic;
using api.App;
using api.Core.Managers;
using api.Models;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    [ApiController]
    [Route("api/loading-codes")]
    public class LoadingCodeController {
        private readonly ITemplateManager _templateManager;

        public LoadingCodeController(ApplicationContext context) {
            _templateManager = new TemplateManager(context);
        }

        [HttpGet]
        [Route("/loading-codes/get-all")]
        public List<LoadingCode> GetAll() {
            return _templateManager.GetAllLoadingCodes();
        }
    }
}
