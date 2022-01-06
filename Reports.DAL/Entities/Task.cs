using System;

namespace Reports.DAL.Entities
{
    [Serializable]
    public class Task
    {
        public Task()
        {
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid EmployeeId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}