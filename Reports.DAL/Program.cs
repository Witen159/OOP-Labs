using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.DAL
{
    class Program
    {
        static void Main( string[] args )
        {
            // string path = @"C:\Users\User\source\repos\Programming_1\Witen159\Reports.DAL\jsonTest.json";
            // Employee employee1 = new Employee
            // {
            //     Id = Guid.NewGuid(),
            //     Name = "Den"
            // };
            // Employee employee2 = new Employee
            // {
            //     Id = Guid.NewGuid(),
            //     Name = "Ben"
            // };
            // List<Employee> employees = new List<Employee>() {employee1, employee2};
            // string json = JsonConvert.SerializeObject(employees);
            // using var streamWriter = new StreamWriter(path);
            // streamWriter.WriteLine(json);
            // streamWriter.Close();
            // var employees2 = JsonConvert.DeserializeObject<Employee[]>(File.ReadAllText(path, Encoding.UTF8)).ToList();
            // if (employees[0].Id == employees2[0].Id)
            //     Console.WriteLine("Works");
        }
    }
}