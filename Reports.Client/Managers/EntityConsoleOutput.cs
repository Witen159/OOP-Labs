using System;
using Reports.DAL.Entities;

namespace Reports.Client.Managers
{
    public class EntityConsoleOutput
    {
        public void EmployeeOutput(Employee employee)
        {
            Console.WriteLine($"Id: {employee.Id}");
            Console.WriteLine($"Name: {employee.Name}");
            Console.WriteLine($"LeadId: {employee.LeadId}");
            Console.WriteLine();
        }

        public void ReportOutput(Report report)
        {
            Console.WriteLine($"Id: {report.Id}");
            Console.WriteLine($"Task Id: {report.TaskId}");
            Console.WriteLine($"Employee Id: {report.EmployeeId}");
            Console.WriteLine($"Report content: {report.ReportContent}");
            Console.WriteLine($"Creation Date: {report.CreationDate}");
            Console.WriteLine();
        }
        
        public void TaskOutput(Task task)
        {
            Console.WriteLine($"Id: {task.Id}");
            Console.WriteLine($"Name: {task.Name}");
            Console.WriteLine($"Employee Id: {task.EmployeeId}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Task state: {task.State}");
            Console.WriteLine($"Start Date: {task.StartDate}");
            Console.WriteLine($"Finish Date: {task.FinishDate}");
            Console.WriteLine("Comments:");
            foreach (var comment in task.Comments)
            {
                Console.WriteLine($"{comment}");
            }
            Console.WriteLine("Change dates:");
            foreach (var change in task.Changes)
            {
                Console.WriteLine($"{change}");
            }
            Console.WriteLine();
        }
    }
}