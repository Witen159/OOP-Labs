using System;

namespace Reports.DAL.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int EmployeeId { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
    }
}