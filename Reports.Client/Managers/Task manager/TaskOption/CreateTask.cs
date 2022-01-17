using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Client.Managers.Task_manager.TaskOption
{
    public class CreateTask : ITaskOption
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            Console.WriteLine("Enter task name");
            string taskName = Console.ReadLine();
            Console.WriteLine("Enter task description");
            string taskDescription = Console.ReadLine();
            
            var request = HttpWebRequest.Create($"https://localhost:5001/tasks?name={taskName}&description={taskDescription}");
            request.Method = WebRequestMethods.Http.Post;
            var response = request.GetResponse();
            
            var responseStream = response.GetResponseStream();
            using var readStream = new StreamReader(responseStream, Encoding.UTF8);
            var responseString = readStream.ReadToEnd();
            
            var task = JsonConvert.DeserializeObject<Task>(responseString);
            
            Console.WriteLine("Created task:");
            _entityConsoleOutput.TaskOutput(task);
        }
    }
}