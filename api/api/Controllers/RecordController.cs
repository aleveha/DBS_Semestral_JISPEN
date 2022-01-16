using System.Collections.Generic;
using api.App;
using api.Core.Managers;
using api.Models;
using api.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    [ApiController]
    [Route("api/records")]
    public class RecordController : Controller {
        private readonly IRecordManager _recordManager;

        public RecordController(ApplicationContext context) {
            _recordManager = new RecordManager(context);
        }

        [HttpGet]
        [Route("/records/get-all")]
        public ActionResult<List<Record>> GetAll(long userId) {
            return Ok(_recordManager.GetAll(userId));
        }

        [HttpGet]
        [Route("/records/get")]
        public ActionResult<Record> Get(long id) {
            Record record = _recordManager.Get(id);
            return record == null ? StatusCode(StatusCodes.Status404NotFound) : Ok(record);
        }

        [HttpPost]
        [Route("/records/add")]
        public ActionResult<Record> Add(Record record) {
            return Ok(_recordManager.Add(record));
        }

        [HttpDelete]
        [Route("/records/delete")]
        public ActionResult<bool> Delete(long id) {
            bool? isDeleted = _recordManager.Delete(id);
            return isDeleted == null ? StatusCode(StatusCodes.Status400BadRequest) : Ok(isDeleted);
        }
    }
}
