namespace EmployeeManagementSystem.Models
{
    public class Overtime
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public DateOnly OvertimeDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public decimal Hours { get; set; } // عدد الساعات الإضافية
        public decimal HourlyRate { get; set; } // سعر الساعة العادية (يحسب تلقائي)
        public decimal OvertimeRate { get; set; } = 1.5m; // مضاعف الإضافي (غالباً 1.5)
        public decimal TotalAmount => Hours * HourlyRate * OvertimeRate;
        public string? Notes { get; set; }
        public string Status { get; set; } = "معلق"; // جديد: معلق - موافقة - مرفوض
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; } = null!;
    }
}