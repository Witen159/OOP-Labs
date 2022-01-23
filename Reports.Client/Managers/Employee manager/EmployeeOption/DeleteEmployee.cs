using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Client.Managers.Employee_manager.EmployeeOption
{
    public class DeleteEmployee : IEmployeeOption
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            Console.WriteLine("Enter employee id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var request = HttpWebRequest.Create($"https://localhost:5001/employees?id={id}");
            request.Method = "DELETE";

            try
            {
                var response = request.GetResponse();

                var responseStream = response.GetResponseStream();
                using var readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                var employee = JsonConvert.DeserializeObject<Employee>(responseString);

                Console.WriteLine("Deleted employee:");
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