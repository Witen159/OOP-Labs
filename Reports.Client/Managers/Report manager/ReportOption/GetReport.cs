using System;
using Reports.Client.Managers.Employee_manager.EmployeeOption;

namespace Reports.Client.Managers.Report_manager.ReportOption
{
    public class GetReport : IReportOption
    {
        private IReportOption _getOption = null;
        public void Option()
        {
            Console.WriteLine("1. Get report by id");
            Console.WriteLine("2. Get all reports");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            
            switch (choice)
            {
                case 1:
                    _getOption = new GetReportById();
                    break;
                case 2:
                    _getOption = new GetAllReports();
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    return;
            }
            _getOption.Option();
        }
    }
}