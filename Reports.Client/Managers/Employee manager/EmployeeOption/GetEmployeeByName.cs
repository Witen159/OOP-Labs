using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Client.Managers.Employee_manager.EmployeeOption
{
    public class GetEmployeeByName : IEmployeeOption
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            Console.WriteLine("Enter employee name:");
            string name = Console.ReadLine();
            var request = HttpWebRequest.Create($"https://localhost:5001/employees/name?name={name}");
            request.Method = WebRequestMethods.Http.Get;

            try
            {
                var response = request.GetResponse();

                var responseStream = response.GetResponseStream();
                using var readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                var employee = JsonConvert.DeserializeObject<Employee>(responseString);

                Console.WriteLine("Found employee by name:");
                _entityConsoleOutput.EmployeeOutput(employee);
            }
            catch (WebException e)
            {
                Console.WriteLine("Employee was not found");
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}