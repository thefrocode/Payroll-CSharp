using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Models;

namespace Payroll.Controllers
{
    public class CompanyDepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyDepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyDepartments
        public async Task<IActionResult> Index()
        {
              return _context.CompanyDepartment != null ? 
                          View(await _context.CompanyDepartment.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CompanyDepartment'  is null.");
        }

        // GET: CompanyDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CompanyDepartment == null)
            {
                return NotFound();
            }

            var companyDepartment = await _context.CompanyDepartment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyDepartment == null)
            {
                return NotFound();
            }

            return View(companyDepartment);
        }

        // GET: CompanyDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CompanyDepartment companyDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyDepartment);
        }

        // GET: CompanyDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CompanyDepartment == null)
            {
                return NotFound();
            }

            var companyDepartment = await _context.CompanyDepartment.FindAsync(id);
            if (companyDepartment == null)
            {
                return NotFound();
            }
            return View(companyDepartment);
        }

        // POST: CompanyDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CompanyDepartment companyDepartment)
        {
            if (id != companyDepartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyDepartmentExists(companyDepartment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(companyDepartment);
        }

        // GET: CompanyDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CompanyDepartment == null)
            {
                return NotFound();
            }

            var companyDepartment = await _context.CompanyDepartment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyDepartment == null)
            {
                return NotFound();
            }

            return View(companyDepartment);
        }

        // POST: CompanyDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CompanyDepartment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CompanyDepartment'  is null.");
            }
            var companyDepartment = await _context.CompanyDepartment.FindAsync(id);
            if (companyDepartment != null)
            {
                _context.CompanyDepartment.Remove(companyDepartment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyDepartmentExists(int id)
        {
          return (_context.CompanyDepartment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
