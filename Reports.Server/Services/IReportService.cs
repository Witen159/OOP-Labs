using System;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IReportService
    {
        Report Create(Guid taskId, Guid employeeId, string reportContent);
        Report FindById(Guid id);
    }
}