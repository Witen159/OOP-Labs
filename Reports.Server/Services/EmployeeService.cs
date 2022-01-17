using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;
using Reports.DAL.Storage;
using Reports.Server.Interfaces;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IStorage _storage =
            new JsonStorage(@"C:\Users\User\source\repos\Programming_1\Witen159\Reports.Server\employees.json");
        public Employee Create(string name, Guid leadId)
        {
            var employee = new Employee
            {
                Name = name,
                Id = Guid.NewGuid(),
                LeadId = leadId
            };
            
            var employees = GetAll().ToList();
            employees.Add(employee);
            _storage.EmployeeSave(employees);

            return employee;
        }
        
        public Employee FindByName(string name)
        {
            return GetAll().FirstOrDefault(x => x.Name == name);
        }

        public Employee FindById(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Employee[] GetAll()
        {
            return _storage.GetEmployees();
        }

        public Employee UpdateLead(Guid id, Guid leadId)
        {
            var employees = GetAll().ToList();
            var employee = employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
                employee.LeadId = leadId;
            _storage.EmployeeSave(employees);

            return employee;
        }

        public Employee Delete(Guid id)
        {
            var employees = GetAll().ToList();
            var employee = employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
                employees.Remove(employee);
            _storage.EmployeeSave(employees);

            return employee;
        }
    }
}