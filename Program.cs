using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Forms;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using var db = new AppDbContext();
            db.Database.Migrate();

            // إنشاء أدمن افتراضي لو مفيش أي يوزر
            if (!db.Users.Any())
            {
                var admin = new User
                {
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"), // Use fully qualified name
                    Role = "Admin"
                };
                db.Users.Add(admin);
                db.SaveChanges();
            }

            Application.Run(new LogInForm());
        }
    }
}