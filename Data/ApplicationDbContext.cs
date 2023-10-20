using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Payroll.Models.Employee> Employee { get; set; } = default!;
        public DbSet<Payroll.Models.CompanyBranch> CompanyBranch { get; set; } = default!;
        public DbSet<Payroll.Models.CompanyDepartment> CompanyDepartment { get; set; } = default!;
        public DbSet<Payroll.Models.Income> Income { get; set; } = default!;
        public DbSet<Payroll.Models.Deduction> Deduction { get; set; } = default!;
        public DbSet<Payroll.Models.IncomeType> IncomeType { get; set; } = default!;
        public DbSet<Payroll.Models.DeductionType> DeductionType { get; set; } = default!;
    }
}