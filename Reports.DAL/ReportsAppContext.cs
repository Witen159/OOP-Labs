using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;

namespace Reports.DAL
{
    public class ReportsAppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }

        public ReportsAppContext()
        {
            Database.EnsureCreated();
        }
    }
}