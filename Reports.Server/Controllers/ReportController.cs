using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Interfaces;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/reports")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public Report Create([FromQuery] Guid taskId, [FromQuery] Guid employeeId, [FromQuery] string reportContent)
        {
            return _service.Create(taskId, employeeId, reportContent);
        }

        [HttpGet]
        [Route("/reports/id")]
        public IActionResult FindById([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return StatusCode((int) HttpStatusCode.BadRequest);
            Report result = _service.FindById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }

        [HttpGet]
        [Route("/reports/getAll")]
        public IActionResult GetAll()
        {
            Report[] result = _service.GetAll();
            if (result.Length != 0)
            {
                return Ok(result);
            }
            return NotFound();
        }
        
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            Report result = _service.Delete(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}