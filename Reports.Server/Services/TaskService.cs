using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public class TaskService : ITaskService
    {
        private const string JsonPath = @"C:\Users\User\source\repos\Programming_1\Witen159\Reports.Server\tasks.json";
        public Task Create(string name, Guid employeeId, string description)
        {
            var task = new Task
            {
                Name = name,
                Id = Guid.NewGuid(),
                EmployeeId = employeeId,
                Description = description,
                StartDate = DateTime.Now
            };
            
            var tasks = new List<Task>();
            if (new FileInfo(JsonPath).Length != 0)
                tasks = JsonConvert.DeserializeObject<Task[]>(File.ReadAllText(JsonPath, Encoding.UTF8)).ToList();
            tasks.Add(task);
            string json = JsonConvert.SerializeObject(tasks);
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);
            streamWriter.Close();

            return task;
        }

        public Task FindByName(string name)
        {
            return JsonConvert.DeserializeObject<Task[]>(File.ReadAllText(JsonPath, Encoding.UTF8))
                .FirstOrDefault(x => x.Name == name);
        }

        public Task FindById(Guid id)
        {
            return JsonConvert.DeserializeObject<Task[]>(File.ReadAllText(JsonPath, Encoding.UTF8))
                .FirstOrDefault(x => x.Id == id);
        }
    }
}