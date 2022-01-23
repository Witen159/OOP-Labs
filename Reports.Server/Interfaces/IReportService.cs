using System;
using Reports.DAL.Entities;

namespace Reports.Server.Interfaces
{
    public interface IReportService
    {
        Report Create(Guid taskId, Guid employeeId, string reportContent);
        Report FindById(Guid id);
        Report[] GetAll();
        Report Delete(Guid id);
    }
}