using System;
using Reports.DAL.Accessory;
using Reports.DAL.Entities;

namespace Reports.Server.Interfaces
{
    public interface ITaskService
    {
        Task Create(string name, string description);
        Task FindByName(string name);
        Task FindById(Guid id);
        Task[] GetAll();
        Task UpdateState(Guid id, TaskState state);
        Task UpdateEmployee(Guid id, Guid employeeId);
        Task AddComment( Guid id, string comment );
        Task Delete(Guid id);
    }
}