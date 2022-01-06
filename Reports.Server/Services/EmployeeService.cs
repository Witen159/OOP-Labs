using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private const string JsonPath = @"C:\Users\User\source\repos\Programming_1\Witen159\Reports.Server\employees.json";
        public Employee Create(string name)
        {
            var employee = new Employee
            {
                Name = name,
                Id = Guid.NewGuid()
            };
            var employees = new List<Employee>();
            if (new FileInfo(JsonPath).Length != 0)
                employees = JsonConvert.DeserializeObject<Employee[]>(File.ReadAllText(JsonPath, Encoding.UTF8)).ToList();
            employees.Add(employee);
            string json = JsonConvert.SerializeObject(employees);
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);

            return employee;
        }
        
        public Employee FindByName(string name)
        {
            return JsonConvert.DeserializeObject<Employee[]>(File.ReadAllText(JsonPath, Encoding.UTF8))
                .FirstOrDefault(x => x.Name == name);
        }

        public Employee FindById(Guid id)
        {
            return JsonConvert.DeserializeObject<Employee[]>(File.ReadAllText(JsonPath, Encoding.UTF8))
                .FirstOrDefault(x => x.Id == id);
        }
    }
}