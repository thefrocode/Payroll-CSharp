namespace Payroll.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string IdNumber { get; set; }

        public string KraPin { get; set; }

        public string NhifNumber { get; set; }

        public string NssfNumber { get; set; }

        public int CompanyBranchId { get; set; }

        public int CompanyDepartmentId { get; set; }

        public CompanyBranch? CompanyBranch { get; set; }

        public CompanyDepartment? CompanyDepartment { get; set; }

        public ICollection<Income> Incomes { get; } = new List<Income>();

        public ICollection<Deduction> Deductions { get; } = new List<Deduction>();

        public Employee()
        {
            
        }

    }
}