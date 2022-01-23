using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Accessory;
using Reports.DAL.Entities;
using Reports.DAL.Storage;
using Reports.Server.Interfaces;

namespace Reports.Server.Services
{
    public class TaskService : ITaskService
    {
        private IStorage _storage = new JsonStorage(@"C:\Users\User\source\repos\Programming_1\Witen159\Reports.Server\tasks.json");
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
            
            var tasks = GetAll().ToList();
            tasks.Add(task);
            _storage.TaskSave(tasks);

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
            return _storage.GetTasks();
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
                else
                    task.Changes.Add(DateTime.Now);
            }

            _storage.TaskSave(tasks);

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
                task.Changes.Add(DateTime.Now);
            }

            _storage.TaskSave(tasks);

            return task;
        }

        public Task AddComment(Guid id, string comment)
        {
            var tasks = GetAll().ToList();
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                task.Comments.Add(comment);
                task.Changes.Add(DateTime.Now);
            }

            _storage.TaskSave(tasks);

            return task;
        }

        public Task Delete(Guid id)
        {
            var tasks = GetAll().ToList();
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
                tasks.Remove(task);
            _storage.TaskSave(tasks);

            return task;
        }
    }
}