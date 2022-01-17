using System;
using Reports.Client.Managers.Employee_manager.EmployeeOption;
using Reports.Client.Managers.Report_manager.ReportOption;

namespace Reports.Client.Managers.Report_manager
{
    public class ReportManager : IManager
    {
        private IReportOption _reportOption = null;
        public void Manager()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create new report");
            Console.WriteLine("2. Get report");
            Console.WriteLine("3. Delete report");
            Console.WriteLine("4. Return to start menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            
            switch (choice)
            {
                case 1:
                    _reportOption = new CreateReport();
                    break;
                case 2:
                    _reportOption = new GetReport();
                    break;
                case 3:
                    _reportOption = new DeleteReport();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    Manager();
                    return;
            }
            
            _reportOption.Option();
            Manager();
        }
    }
}