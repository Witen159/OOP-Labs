using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Accessory;
using Reports.DAL.Entities;
using Reports.Server.Interfaces;

namespace Reports.Server.Services
{
    public class TaskService : ITaskService
    {
        private const string JsonPath = @"C:\Users\User\source\repos\Programming_1\Witen159\Reports.Server\tasks.json";
        public Task Create(string name, string description)
        {
            var task = new Task
            {
                Name = name,
                Id = Guid.NewGuid(),
                State = TaskState.Open,
                Description = description,
                StartDate = DateTime.Now
            };
            
            var tasks = new List<Task>();
            if (new FileInfo(JsonPath).Length != 0)
                tasks = GetAll().ToList();
            tasks.Add(task);
            string json = JsonConvert.SerializeObject(tasks);
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);
            streamWriter.Close();

            return task;
        }

        public Task FindByName(string name)
        {
            return GetAll().FirstOrDefault(x => x.Name == name);
        }

        public Task FindById(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Task[] GetAll()
        {
            return JsonConvert.DeserializeObject<Task[]>(File.ReadAllText(JsonPath, Encoding.UTF8));
        }

        public Task UpdateState(Guid id, TaskState state)
        {
            var tasks = GetAll().ToList();
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                task.State = state;
                if (state == TaskState.Resolved)
                    task.FinishDate = DateTime.Now;
            }

            string json = JsonConvert.SerializeObject(tasks);
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);
            streamWriter.Close();

            return task;
        }

        public Task UpdateEmployee(Guid id, Guid employeeId)
        {
            var tasks = GetAll().ToList();
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                task.EmployeeId = employeeId;
                task.State = TaskState.Active;
            }

            string json = JsonConvert.SerializeObject(tasks);
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);
            streamWriter.Close();

            return task;
        }

        public Task Delete(Guid id)
        {
            var tasks = GetAll().ToList();
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
                tasks.Remove(task);
            string json = JsonConvert.SerializeObject(tasks);
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);
            streamWriter.Close();

            return task;
        }
    }
}