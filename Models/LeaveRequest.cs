namespace EmployeeManagementSystem.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public DateOnly Date { get; set; }
        public TimeOnly? FromTime { get; set; }
        public TimeOnly? ToTime { get; set; }
        public string Type { get; set; } = "إذن ساعات"; // إذن ساعات - إجازة يوم - غياب
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
        public string? RejectReason { get; set; } // سبب الرفض
        public int? ApprovedById { get; set; }
        public User? ApprovedBy { get; set; }

       
    }
}