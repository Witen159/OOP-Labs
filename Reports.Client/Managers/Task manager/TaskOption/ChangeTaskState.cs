using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Client.Managers.Task_manager.TaskOption
{
    public class ChangeTaskState : ITaskOption
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            Console.WriteLine("Enter task id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose task state:");
            Console.WriteLine("1. Open");
            Console.WriteLine("2. Active");
            Console.WriteLine("3. Resolved");
            int state = Convert.ToInt32(Console.ReadLine()) - 1;
            var request = HttpWebRequest.Create($"https://localhost:5001/tasks/state?id={id}&state={state}");
            request.Method = "PATCH";

            try
            {
                var response = request.GetResponse();

                var responseStream = response.GetResponseStream();
                using var readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                var task = JsonConvert.DeserializeObject<Task>(responseString);

                Console.WriteLine("Task with new state:");
                _entityConsoleOutput.TaskOutput(task);
            }
            catch (WebException e)
            {
                Console.WriteLine("Task was not found");
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}