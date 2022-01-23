using System;
using System.Collections.Generic;
using System.Dynamic;
using Reports.DAL.Entities;

namespace Reports.DAL.Storage
{
    public interface IStorage
    {
        void EmployeeSave(List<Employee> employees);
        void TaskSave(List<Task> tasks);
        void ReportSave(List<Report> reports);
        Employee[] GetEmployees();
        Task[] GetTasks();
        Report[] GetReports();
    }
}