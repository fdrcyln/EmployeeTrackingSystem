using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EmployeeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=FDRCYLN\\SQLEXPRESS;Database=EmployeeTrackingSystem;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        }

        public DbSet<Branch> Branchs  { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<EmployeeAssignment> EmployeeAssignments { get; set; }

       
    }
}
