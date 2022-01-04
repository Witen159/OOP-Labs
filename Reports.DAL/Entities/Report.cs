using System;

namespace Reports.DAL.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string ReportContent { get; set; }
        public DateTime CreationDate { get; set; }
    }
}