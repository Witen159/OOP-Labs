using System;

namespace Reports.Client.Managers.Employee_manager.EmployeeOption
{
    public class GetEmployee : IEmployeeOption
    {
        private IEmployeeOption _getOption = null;
        public void Option()
        {
            Console.WriteLine("1. Get employee by name");
            Console.WriteLine("2. Get employee by id");
            Console.WriteLine("3. Get all employees");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            
            switch (choice)
            {
                case 1:
                    _getOption = new GetEmployeeByName();
                    break;
                case 2:
                    _getOption = new GetEmployeeById();
                    break;
                case 3:
                    _getOption = new GetAllEmployee();
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    return;
            }
            _getOption.Option();
        }
    }
}