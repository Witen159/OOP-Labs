using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Client.Managers.Report_manager.ReportOption
{
    public class GetAllReports : IReportOption
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            var request = HttpWebRequest.Create("https://localhost:5001/reports/getAll");
            request.Method = WebRequestMethods.Http.Get;

            try
            {
                var response = request.GetResponse();

                var responseStream = response.GetResponseStream();
                using var readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                var reports = JsonConvert.DeserializeObject<Report[]>(responseString);

                Console.WriteLine("All reports:");
                foreach (var report in reports)
                {
                    _entityConsoleOutput.ReportOutput(report);
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("Reports was not found");
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}