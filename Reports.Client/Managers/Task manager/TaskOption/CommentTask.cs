using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Client.Managers.Task_manager.TaskOption
{
    public class CommentTask : ITaskOption
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            Console.WriteLine("Enter task id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter comment:");
            string comment = Console.ReadLine();
            var request = HttpWebRequest.Create($"https://localhost:5001/tasks/comment?id={id}&comment={comment}");
            request.Method = "PATCH";

            try
            {
                var response = request.GetResponse();

                var responseStream = response.GetResponseStream();
                using var readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                var task = JsonConvert.DeserializeObject<Task>(responseString);

                Console.WriteLine("Task with new comment:");
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