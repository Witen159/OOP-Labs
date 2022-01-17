using System;
using Reports.Client.Managers;
using Reports.Client.Managers.Employee_manager;
using Reports.Client.Managers.Report_manager;
using Reports.Client.Managers.Task_manager;

namespace Reports.Client
{
    public class Application
    {
        private IManager _employeeManager = new EmployeeManager();
        private IManager _taskManager = new TaskManager();
        private IManager _reportManager = new ReportManager();
        public Application()
        {
            Console.WriteLine("Please use command numbers is our application");
            Console.WriteLine();
        }
        public void StartApplication()
        {
            Console.WriteLine("Choose manager:");
            Console.WriteLine("1. Employee manager");
            Console.WriteLine("2. Task manager");
            Console.WriteLine("3. Report manager");
            Console.WriteLine("4. Exit Menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    _employeeManager.Manager();
                    break;
                case 2:
                    _taskManager.Manager();
                    break;
                case 3:
                    _reportManager.Manager();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    break;
            }

            StartApplication();
        }
    }
}