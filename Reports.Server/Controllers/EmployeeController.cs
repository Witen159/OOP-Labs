using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Interfaces;
using Reports.Server.Services;
using Task = System.Threading.Tasks.Task;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public Employee Create([FromQuery] string name, [FromQuery] Guid leadId)
        {
            return _service.Create(name, leadId);
        }

        [HttpGet]
        [Route("/employees/name")]
        public IActionResult FindByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return StatusCode((int) HttpStatusCode.BadRequest);
            Employee result = _service.FindByName(name);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
        
        [HttpGet]
        [Route("/employees/id")]
        public IActionResult FindById([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return StatusCode((int) HttpStatusCode.BadRequest);
            Employee result = _service.FindById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }

        [HttpGet]
        [Route("/employees/getAll")]
        public IActionResult GetAll()
        {
            Employee[] result = _service.GetAll();
            if (result.Length != 0)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPatch]
        public IActionResult UpdateLead(Guid id, Guid leadId)
        {
            Employee result = _service.UpdateLead(id, leadId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            Employee result = _service.Delete(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}