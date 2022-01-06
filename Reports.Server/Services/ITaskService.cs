using System;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface ITaskService
    {
        Task Create(string name, Guid employeeId, string description);
        Task FindByName(string name);

        Task FindById(Guid id);
    }
}