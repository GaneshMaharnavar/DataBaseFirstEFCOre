using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBaseFirstEFCOre.Models;

namespace DataBaseFirstEFCOre.Controllers
{
    public class HomeController : Controller
    {
        private readonly Dotnet8Context _context;

        public HomeController(Dotnet8Context context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student8s.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student8 = await _context.Student8s
                .FirstOrDefaultAsync(m => m.SId == id);
            if (student8 == null)
            {
                return NotFound();
            }

            return View(student8);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SId,Sname,City")] Student8 student8)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student8);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student8);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student8 = await _context.Student8s.FindAsync(id);
            if (student8 == null)
            {
                return NotFound();
            }
            return View(student8);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SId,Sname,City")] Student8 student8)
        {
            if (id != student8.SId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student8);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student8Exists(student8.SId))
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
            return View(student8);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student8 = await _context.Student8s
                .FirstOrDefaultAsync(m => m.SId == id);
            if (student8 == null)
            {
                return NotFound();
            }

            return View(student8);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student8 = await _context.Student8s.FindAsync(id);
            if (student8 != null)
            {
                _context.Student8s.Remove(student8);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student8Exists(int id)
        {
            return _context.Student8s.Any(e => e.SId == id);
        }
    }
}
