using Microsoft.Extensions.Hosting;

namespace Payroll.Models
{
    public class CompanyBranch
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; } = new List<Employee>();

        public CompanyBranch()
        {
            
        }
    }
}
