using System;
using System.Collections.Generic;
using Reports.DAL.Accessory;

namespace Reports.DAL.Entities
{
    [Serializable]
    public class Task
    {
        public Task()
        {
            Comments = new List<string>();
            Changes = new List<DateTime>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid EmployeeId { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> Changes { get; set; }
    }
}