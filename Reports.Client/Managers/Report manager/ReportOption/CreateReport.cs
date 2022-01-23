using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Client.Managers.Report_manager.ReportOption
{
    public class CreateReport : IReportOption
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            Console.WriteLine("Enter report content");
            string reportContent = Console.ReadLine();
            Console.WriteLine("Enter task id");
            int taskId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employee id");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            
            var request = HttpWebRequest.Create($"https://localhost:5001/reports?taskId={taskId}&employeeId={employeeId}&reportContent={reportContent}");
            request.Method = WebRequestMethods.Http.Post;
            var response = request.GetResponse();
            
            var responseStream = response.GetResponseStream();
            using var readStream = new StreamReader(responseStream, Encoding.UTF8);
            var responseString = readStream.ReadToEnd();
            
            var report = JsonConvert.DeserializeObject<Report>(responseString);

            Console.WriteLine("Created report:");
            _entityConsoleOutput.ReportOutput(report);
        }
    }
}