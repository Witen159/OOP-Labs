using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.DAL
{
    class Program
    {
        static void Main( string[] args )
        {
            Employee employee1 = new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Den"
            };
            Employee employee2 = new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Ben"
            };
            List<Employee> employees = new List<Employee>() {employee1, employee2};
            string json = JsonConvert.SerializeObject(employees);
            using var streamWriter = new StreamWriter("jsonTest.json");
            streamWriter.WriteLine(json);
        }
    }
}