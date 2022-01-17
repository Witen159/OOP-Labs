using System;
using Reports.Client.Managers.Employee_manager.EmployeeOption;

namespace Reports.Client.Managers.Employee_manager
{
    public class EmployeeManager : IManager
    {
        private IEmployeeOption _employeeOption = null;
        public void Manager()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create new employee");
            Console.WriteLine("2. Get employee");
            Console.WriteLine("3. Change employee lead");
            Console.WriteLine("4. Delete employee");
            Console.WriteLine("5. Return to start menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            
            switch (choice)
            {
                case 1:
                    _employeeOption = new CreateEmployee();
                    break;
                case 2:
                    _employeeOption = new GetEmployee();
                    break;
                case 3:
                    _employeeOption = new ChangeEmployeeLead();
                    break;
                case 4:
                    _employeeOption = new DeleteEmployee();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    Manager();
                    return;
            }
            
            _employeeOption.Option();
            Manager();
        }
    }
}