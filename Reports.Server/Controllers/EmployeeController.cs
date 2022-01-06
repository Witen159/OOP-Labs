using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;

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
        public Employee Create([FromQuery] string name)
        {
            return _service.Create(name);
        }
    }
}