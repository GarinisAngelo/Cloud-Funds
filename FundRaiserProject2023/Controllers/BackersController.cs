using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FundRaiserProject2023.DbContexts;
using FundRaiserProject2023.Models;

namespace FundRaiserProject2023.Controllers
{
    public class BackersController : Controller
    {
        private readonly OurDbContext _context;

        public BackersController(OurDbContext context)
        {
            _context = context;
        }

		public IActionResult BackerHomePage()
        {
            return View();
        }

        public async Task<IActionResult> BackerIndex()
        {
            return _context.Backers != null ?
                        View(await _context.Backers.ToListAsync()) :
                        Problem("Entity set 'OurDbContext.Backers'  is null.");
        }

        public IActionResult BackerCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BackerCreate([Bind("Id,Name")] Backer backer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(backer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(backer);
        }

        public IActionResult BackerCreateSuccessful()
        {
            return View();
        }

        // GET: Backers
        public async Task<IActionResult> Index()
        {
              return _context.Backers != null ? 
                          View(await _context.Backers.ToListAsync()) :
                          Problem("Entity set 'OurDbContext.Backers'  is null.");
        }

        // GET: Backers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Backers == null)
            {
                return NotFound();
            }

            var backer = await _context.Backers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (backer == null)
            {
                return NotFound();
            }

            return View(backer);
        }

        // GET: Backers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Backers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Backer backer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(backer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(backer);
        }

        // GET: Backers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Backers == null)
            {
                return NotFound();
            }

            var backer = await _context.Backers.FindAsync(id);
            if (backer == null)
            {
                return NotFound();
            }
            return View(backer);
        }

        // POST: Backers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Backer backer)
        {
            if (id != backer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(backer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BackerExists(backer.Id))
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
            return View(backer);
        }

        // GET: Backers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Backers == null)
            {
                return NotFound();
            }

            var backer = await _context.Backers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (backer == null)
            {
                return NotFound();
            }

            return View(backer);
        }

        // POST: Backers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Backers == null)
            {
                return Problem("Entity set 'OurDbContext.Backers'  is null.");
            }
            var backer = await _context.Backers.FindAsync(id);
            if (backer != null)
            {
                _context.Backers.Remove(backer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BackerExists(int id)
        {
          return (_context.Backers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        
    }
}
