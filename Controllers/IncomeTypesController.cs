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
    public class IncomeTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncomeTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IncomeTypes
        public async Task<IActionResult> Index()
        {
              return _context.IncomeType != null ? 
                          View(await _context.IncomeType.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.IncomeType'  is null.");
        }

        // GET: IncomeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IncomeType == null)
            {
                return NotFound();
            }

            var incomeType = await _context.IncomeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeType == null)
            {
                return NotFound();
            }

            return View(incomeType);
        }

        // GET: IncomeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncomeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code")] IncomeType incomeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incomeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incomeType);
        }

        // GET: IncomeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IncomeType == null)
            {
                return NotFound();
            }

            var incomeType = await _context.IncomeType.FindAsync(id);
            if (incomeType == null)
            {
                return NotFound();
            }
            return View(incomeType);
        }

        // POST: IncomeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code")] IncomeType incomeType)
        {
            if (id != incomeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeTypeExists(incomeType.Id))
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
            return View(incomeType);
        }

        // GET: IncomeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IncomeType == null)
            {
                return NotFound();
            }

            var incomeType = await _context.IncomeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeType == null)
            {
                return NotFound();
            }

            return View(incomeType);
        }

        // POST: IncomeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IncomeType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.IncomeType'  is null.");
            }
            var incomeType = await _context.IncomeType.FindAsync(id);
            if (incomeType != null)
            {
                _context.IncomeType.Remove(incomeType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeTypeExists(int id)
        {
          return (_context.IncomeType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
