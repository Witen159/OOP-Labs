using System;
using Reports.Client.Managers.Employee_manager.EmployeeOption;

namespace Reports.Client.Managers.Task_manager.TaskOption
{
    public class GetTask : ITaskOption
    {
        private ITaskOption _getOption = null;
        public void Option()
        {
            Console.WriteLine("1. Get task by name");
            Console.WriteLine("2. Get task by id");
            Console.WriteLine("3. Get all tasks");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            
            switch (choice)
            {
                case 1:
                    _getOption = new GetTaskByName();
                    break;
                case 2:
                    _getOption = new GetTaskById();
                    break;
                case 3:
                    _getOption = new GetAllTasks();
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    return;
            }
            _getOption.Option();
        }
    }
}