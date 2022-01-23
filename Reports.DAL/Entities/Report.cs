using System;

namespace Reports.DAL.Entities
{
    [Serializable]
    public class Report
    {
        public Report()
        {
        }
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public string ReportContent { get; set; }
        public DateTime CreationDate { get; set; }
    }
}