using System;

namespace Reports.DAL.Entities
{
    [Serializable]
    public class Employee
    {
        public Employee()
        {
        }
        public Guid Id { get; set; }
        public Guid LeadId { get; set; }
        public string Name { get; set; }
    }
}