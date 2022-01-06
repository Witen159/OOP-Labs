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
        private const string JsonPath = "employees.json";
        public Employee Create(string name)
        {
            var employee = new Employee
            {
                Name = name,
                Id = Guid.NewGuid()
            };
            var employees = JsonConvert.DeserializeObject<Employee[]>(File.ReadAllText(JsonPath, Encoding.UTF8)).ToList();
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
            Guid fakeGuid = Guid.Parse("ac8ac3ce-f738-4cd6-b131-1aa0e16eaadc");
            if (id == fakeGuid)
            {
                // return new Employee(fakeGuid, "Abobus");
            }

            return null;
        }
    }
}