using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Client.Managers.Report_manager.ReportOption
{
    public class GetReportById : IReportOption
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            Console.WriteLine("Enter report id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var request = HttpWebRequest.Create($"https://localhost:5001/reports/id?id={id}");
            request.Method = WebRequestMethods.Http.Get;

            try
            {
                var response = request.GetResponse();

                var responseStream = response.GetResponseStream();
                using var readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                var report = JsonConvert.DeserializeObject<Report>(responseString);

                Console.WriteLine("Found report by id:");
                _entityConsoleOutput.ReportOutput(report);
            }
            catch (WebException e)
            {
                Console.WriteLine("report was not found");
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}