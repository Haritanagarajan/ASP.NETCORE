using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETCORE.Models;

namespace ASP.NETCORE.Controllers
{
    public class Sample1Controller : Controller
    {
        private readonly AspcoreContext _context;

        public Sample1Controller(AspcoreContext context)
        {
            _context = context;
        }

        // GET: Sample1
        public async Task<IActionResult> Index()
        {
              return _context.Sample1s != null ? 
                          View(await _context.Sample1s.ToListAsync()) :
                          Problem("Entity set 'AspcoreContext.Sample1s'  is null.");
        }

        // GET: Sample1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sample1s == null)
            {
                return NotFound();
            }

            var sample1 = await _context.Sample1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sample1 == null)
            {
                return NotFound();
            }

            return View(sample1);
        }

        // GET: Sample1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sample1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Sample1 sample1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sample1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sample1);
        }

        // GET: Sample1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sample1s == null)
            {
                return NotFound();
            }

            var sample1 = await _context.Sample1s.FindAsync(id);
            if (sample1 == null)
            {
                return NotFound();
            }
            return View(sample1);
        }

        // POST: Sample1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Sample1 sample1)
        {
            if (id != sample1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sample1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sample1Exists(sample1.Id))
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
            return View(sample1);
        }

        // GET: Sample1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sample1s == null)
            {
                return NotFound();
            }

            var sample1 = await _context.Sample1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sample1 == null)
            {
                return NotFound();
            }

            return View(sample1);
        }

        // POST: Sample1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sample1s == null)
            {
                return Problem("Entity set 'AspcoreContext.Sample1s'  is null.");
            }
            var sample1 = await _context.Sample1s.FindAsync(id);
            if (sample1 != null)
            {
                _context.Sample1s.Remove(sample1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sample1Exists(int id)
        {
          return (_context.Sample1s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
