using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<Attendance> Attendances => Set<Attendance>();
        public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
        public DbSet<Shift> Shifts => Set<Shift>();
        public DbSet<Advance> Advances => Set<Advance>();
        public DbSet<Overtime> Overtimes => Set<Overtime>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }
    }
}