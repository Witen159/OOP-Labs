using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Client.Managers.Employee_manager.EmployeeOption
{
    public class CreateEmployee : IEmployeeOption
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            Console.WriteLine("Enter employee name");
            string name = Console.ReadLine();
            
            var request = HttpWebRequest.Create($"https://localhost:5001/employees?name={name}");
            request.Method = WebRequestMethods.Http.Post;
            var response = request.GetResponse();
            
            var responseStream = response.GetResponseStream();
            using var readStream = new StreamReader(responseStream, Encoding.UTF8);
            var responseString = readStream.ReadToEnd();
            
            var employee = JsonConvert.DeserializeObject<Employee>(responseString);

            Console.WriteLine("Created employee:");
            _entityConsoleOutput.EmployeeOutput(employee);
        }
    }
}