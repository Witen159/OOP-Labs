using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;
using Reports.Server.Interfaces;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private const string JsonPath = @"C:\Users\User\source\repos\Programming_1\Witen159\Reports.Server\employees.json";
        public Employee Create(string name, Guid leadId)
        {
            var employee = new Employee
            {
                Name = name,
                Id = Guid.NewGuid(),
                LeadId = leadId
            };
            
            var employees = new List<Employee>();
            if (new FileInfo(JsonPath).Length != 0)
                employees = GetAll().ToList();
            employees.Add(employee);
            string json = JsonConvert.SerializeObject(employees);
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);
            streamWriter.Close();

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
            return JsonConvert.DeserializeObject<Employee[]>(File.ReadAllText(JsonPath, Encoding.UTF8));
        }

        public Employee UpdateLead(Guid id, Guid leadId)
        {
            var employees = GetAll().ToList();
            var employee = employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
                employee.LeadId = leadId;
            string json = JsonConvert.SerializeObject(employees);
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);
            streamWriter.Close();

            return employee;
        }

        public Employee Delete(Guid id)
        {
            var employees = GetAll().ToList();
            var employee = employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
                employees.Remove(employee);
            string json = JsonConvert.SerializeObject(employees);
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);
            streamWriter.Close();

            return employee;
        }
    }
}