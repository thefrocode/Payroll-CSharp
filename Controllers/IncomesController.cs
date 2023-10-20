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
    public class IncomesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Incomes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Income.Include(i => i.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Incomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Income == null)
            {
                return NotFound();
            }

            var income = await _context.Income
                .Include(i => i.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (income == null)
            {
                return NotFound();
            }

            return View(income);
        }

        // GET: Incomes/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name");
            return View();
        }

        // POST: Incomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Amount,Month,Year")] Income income)
        {
            if (ModelState.IsValid)
            {
                _context.Add(income);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name", income.EmployeeId);
            return View(income);
        }

        // GET: Incomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Income == null)
            {
                return NotFound();
            }

            var income = await _context.Income.FindAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name", income.EmployeeId);
            return View(income);
        }

        // POST: Incomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Amount,Month,Year")] Income income)
        {
            if (id != income.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(income);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeExists(income.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name", income.EmployeeId);
            return View(income);
        }

        // GET: Incomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Income == null)
            {
                return NotFound();
            }

            var income = await _context.Income
                .Include(i => i.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (income == null)
            {
                return NotFound();
            }

            return View(income);
        }

        // POST: Incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Income == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Income'  is null.");
            }
            var income = await _context.Income.FindAsync(id);
            if (income != null)
            {
                _context.Income.Remove(income);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeExists(int id)
        {
          return (_context.Income?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
