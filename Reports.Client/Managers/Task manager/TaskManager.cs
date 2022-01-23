using System;
using Reports.Client.Managers.Employee_manager.EmployeeOption;
using Reports.Client.Managers.Task_manager.TaskOption;

namespace Reports.Client.Managers.Task_manager
{
    public class TaskManager : IManager
    {
        private ITaskOption _taskOption = null;
        public void Manager()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create new task");
            Console.WriteLine("2. Get task");
            Console.WriteLine("3. Update task");
            Console.WriteLine("4. Delete task");
            Console.WriteLine("5. Return to start menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            
            switch (choice)
            {
                case 1:
                    _taskOption = new CreateTask();
                    break;
                case 2:
                    _taskOption = new GetTask();
                    break;
                case 3:
                    _taskOption = new UpdateTask();
                    break;
                case 4:
                    _taskOption = new DeleteTask();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    Manager();
                    return;
            }
            
            _taskOption.Option();
            Manager();
        }
    }
}