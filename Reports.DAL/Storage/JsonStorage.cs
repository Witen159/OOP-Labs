using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.DAL.Storage
{
    // Отдельные методы для всего, так как для сериализации/десериализации требуются конкретные типы
    public class JsonStorage : IStorage
    {
        public JsonStorage( string path )
        {
            JsonPath = path;
        }
        
        public string JsonPath { get; }

        public void EmployeeSave(List<Employee> employees)
        {
            string json = JsonConvert.SerializeObject(employees);
            JsonSave(json);
        }

        public void TaskSave(List<Task> tasks)
        {
            string json = JsonConvert.SerializeObject(tasks);
            JsonSave(json);
        }

        public void ReportSave(List<Report> reports)
        {
            string json = JsonConvert.SerializeObject(reports);
            JsonSave(json);
        }

        public Employee[] GetEmployees()
        {
            if (new FileInfo(JsonPath).Length == 0)
                return new Employee[] { };
            return JsonConvert.DeserializeObject<Employee[]>(File.ReadAllText(JsonPath, Encoding.UTF8));
        }

        public Task[] GetTasks()
        {
            if (new FileInfo(JsonPath).Length == 0)
                return new Task[] { };
            return JsonConvert.DeserializeObject<Task[]>(File.ReadAllText(JsonPath, Encoding.UTF8));
        }

        public Report[] GetReports()
        {
            if (new FileInfo(JsonPath).Length == 0)
                return new Report[] { };
            return JsonConvert.DeserializeObject<Report[]>(File.ReadAllText(JsonPath, Encoding.UTF8));
        }

        private void JsonSave(string json)
        {
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);
            streamWriter.Close();
        }
    }
}