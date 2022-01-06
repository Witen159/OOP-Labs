using System;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Employee Create(string name)
        {
            var employee = new Employee
            {
                Name = name,
                Id = Guid.NewGuid()
            };
            return employee;
        }
    }
}