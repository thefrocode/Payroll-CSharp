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
    public class DeductionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeductionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Deductions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Deduction.Include(d => d.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Deductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deduction == null)
            {
                return NotFound();
            }

            var deduction = await _context.Deduction
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deduction == null)
            {
                return NotFound();
            }

            return View(deduction);
        }

        // GET: Deductions/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id");
            return View();
        }

        // POST: Deductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Amount,Month,Year")] Deduction deduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", deduction.EmployeeId);
            return View(deduction);
        }

        // GET: Deductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Deduction == null)
            {
                return NotFound();
            }

            var deduction = await _context.Deduction.FindAsync(id);
            if (deduction == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", deduction.EmployeeId);
            return View(deduction);
        }

        // POST: Deductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Amount,Month,Year")] Deduction deduction)
        {
            if (id != deduction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeductionExists(deduction.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", deduction.EmployeeId);
            return View(deduction);
        }

        // GET: Deductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Deduction == null)
            {
                return NotFound();
            }

            var deduction = await _context.Deduction
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deduction == null)
            {
                return NotFound();
            }

            return View(deduction);
        }

        // POST: Deductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Deduction == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Deduction'  is null.");
            }
            var deduction = await _context.Deduction.FindAsync(id);
            if (deduction != null)
            {
                _context.Deduction.Remove(deduction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeductionExists(int id)
        {
          return (_context.Deduction?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
