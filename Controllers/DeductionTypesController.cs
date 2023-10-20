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
    public class DeductionTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeductionTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeductionTypes
        public async Task<IActionResult> Index()
        {
              return _context.DeductionType != null ? 
                          View(await _context.DeductionType.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DeductionType'  is null.");
        }

        // GET: DeductionTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeductionType == null)
            {
                return NotFound();
            }

            var deductionType = await _context.DeductionType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deductionType == null)
            {
                return NotFound();
            }

            return View(deductionType);
        }

        // GET: DeductionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeductionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code")] DeductionType deductionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deductionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deductionType);
        }

        // GET: DeductionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeductionType == null)
            {
                return NotFound();
            }

            var deductionType = await _context.DeductionType.FindAsync(id);
            if (deductionType == null)
            {
                return NotFound();
            }
            return View(deductionType);
        }

        // POST: DeductionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code")] DeductionType deductionType)
        {
            if (id != deductionType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deductionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeductionTypeExists(deductionType.Id))
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
            return View(deductionType);
        }

        // GET: DeductionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeductionType == null)
            {
                return NotFound();
            }

            var deductionType = await _context.DeductionType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deductionType == null)
            {
                return NotFound();
            }

            return View(deductionType);
        }

        // POST: DeductionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeductionType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DeductionType'  is null.");
            }
            var deductionType = await _context.DeductionType.FindAsync(id);
            if (deductionType != null)
            {
                _context.DeductionType.Remove(deductionType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeductionTypeExists(int id)
        {
          return (_context.DeductionType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
