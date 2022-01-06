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
    public class ReportService : IReportService
    {
        private const string JsonPath = @"C:\Users\User\source\repos\Programming_1\Witen159\Reports.Server\reports.json";
        public Report Create(Guid taskId, Guid employeeId, string reportContent)
        {
            var report = new Report
            {
                Id = Guid.NewGuid(),
                TaskId = taskId,
                EmployeeId = employeeId,
                ReportContent = reportContent,
                CreationDate = DateTime.Now
            };
            
            var reports = new List<Report>();
            if (new FileInfo(JsonPath).Length != 0)
                reports = GetAll().ToList();
            reports.Add(report);
            string json = JsonConvert.SerializeObject(reports);
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);
            streamWriter.Close();

            return report;
        }

        public Report FindById(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Report[] GetAll()
        {
            return JsonConvert.DeserializeObject<Report[]>(File.ReadAllText(JsonPath, Encoding.UTF8));
        }

        public Report Delete(Guid id)
        {
            var reports = GetAll().ToList();
            var report = reports.FirstOrDefault(x => x.Id == id);
            if (report != null)
                reports.Remove(report);
            string json = JsonConvert.SerializeObject(reports);
            using var streamWriter = new StreamWriter(JsonPath);
            streamWriter.WriteLine(json);
            streamWriter.Close();

            return report;
        }
    }
}