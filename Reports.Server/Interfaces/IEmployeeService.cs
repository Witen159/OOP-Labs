using System;
using Reports.DAL.Entities;

namespace Reports.Server.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(string name, Guid leadId);
        Employee FindByName(string name);
        Employee FindById(Guid id);
        Employee[] GetAll();
        Employee UpdateLead(Guid id, Guid leadId);
        Employee Delete(Guid id);
    }
}