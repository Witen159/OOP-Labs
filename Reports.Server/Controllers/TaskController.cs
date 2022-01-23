using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Accessory;
using Reports.DAL.Entities;
using Reports.Server.Interfaces;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public Task Create([FromQuery] string name, [FromQuery] string description)
        {
            return _service.Create(name, description);
        }
        
        [HttpGet]
        [Route("/tasks/name")]
        public IActionResult FindByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return StatusCode((int) HttpStatusCode.BadRequest);
            Task result = _service.FindByName(name);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
        
        [HttpGet]
        [Route("/tasks/id")]
        public IActionResult FindById([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return StatusCode((int) HttpStatusCode.BadRequest);
            Task result = _service.FindById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }

        [HttpGet]
        [Route("/tasks/getAll")]
        public IActionResult GetAll()
        {
            Task[] result = _service.GetAll();
            if (result.Length != 0)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("/tasks/state")]
        public IActionResult UpdateState(Guid id, TaskState state)
        {
            Task result = _service.UpdateState(id, state);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        
        [HttpPatch]
        [Route("/tasks/employee")]
        public IActionResult UpdateEmployee(Guid id, Guid employeeId)
        {
            Task result = _service.UpdateEmployee(id, employeeId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        
        [HttpPatch]
        [Route("/tasks/comment")]
        public IActionResult UpdateComment(Guid id, string comment)
        {
            Task result = _service.AddComment(id, comment);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            Task result = _service.Delete(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}