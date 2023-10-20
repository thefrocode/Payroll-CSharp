namespace Payroll.Models
{
    public class Deduction
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Employee? Employee { get; set; }
    }
}
