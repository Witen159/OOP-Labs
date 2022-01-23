using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Client.Managers.Employee_manager.EmployeeOption
{
    public class GetAllEmployee : IEmployeeOption
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            var request = HttpWebRequest.Create("https://localhost:5001/employees/getAll");
            request.Method = WebRequestMethods.Http.Get;

            try
            {
                var response = request.GetResponse();

                var responseStream = response.GetResponseStream();
                using var readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                var employees = JsonConvert.DeserializeObject<Employee[]>(responseString);

                Console.WriteLine("All employees:");
                foreach (var employee in employees)
                {
                    _entityConsoleOutput.EmployeeOutput(employee);
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("Employee was not found");
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}