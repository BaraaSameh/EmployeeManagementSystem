namespace EmployeeManagementSystem.Models
{
    public class Advance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public decimal Amount { get; set; } // مبلغ السلفة
        public DateOnly AdvanceDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public string? Notes { get; set; } // ملاحظات
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedById { get; set; } // مين سجل السلفة (الأدمن أو المانجر)
        public User CreatedBy { get; set; } = null!;
    }
}

// End of file Advance.cs

// EOF
