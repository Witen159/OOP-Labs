using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Client.Managers.Task_manager.TaskOption
{
    public class GetAllTasks : ITaskOption
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            var request = HttpWebRequest.Create("https://localhost:5001/tasks/getAll");
            request.Method = WebRequestMethods.Http.Get;

            try
            {
                var response = request.GetResponse();

                var responseStream = response.GetResponseStream();
                using var readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                var tasks = JsonConvert.DeserializeObject<Task[]>(responseString);

                Console.WriteLine("All tasks:");
                foreach (var task in tasks)
                {
                    _entityConsoleOutput.TaskOutput(task);
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("Task was not found");
                Console.Error.WriteLine(e.Message);
            }        
        }
    }
}