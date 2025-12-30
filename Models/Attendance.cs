namespace EmployeeManagementSystem.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public DateOnly Date { get; set; }
        public TimeOnly? CheckIn { get; set; }
        public TimeOnly? CheckOut { get; set; }
        public decimal TotalHours => CheckOut.HasValue && CheckIn.HasValue
            ? (decimal)(CheckOut.Value - CheckIn.Value).TotalHours
            : 0;
    }
}