using EmployeeManagementSystem.Models;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public DateTime HireDate { get; set; } = DateTime.Now;
    public decimal BaseSalary { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public int PositionId { get; set; }
    public Position Position { get; set; } = null!;
    public User? User { get; set; }

    // ==== الجديد: حقل الصورة ====
    public string? PhotoPath { get; set; }           // مسار الصورة على الجهاز (مثل: C:\Photos\ahmed.jpg)
    public byte[]? PhotoData { get; set; }           // أو نخزن الصورة كـ bytes في الداتابيز (أفضل للـ LocalDB)

    public int? ShiftId { get; set; }
    public Shift? Shift { get; set; }
}