namespace EmployeeManagementSystem.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // مثل "الشيفت الصباحي"
        public TimeOnly FromTime { get; set; }
        public TimeOnly ToTime { get; set; }
        public decimal WorkingHours => (decimal)(ToTime - FromTime).TotalHours;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>(); // لو عايز تربط كل موظف بشيفت ثابت
    }
}