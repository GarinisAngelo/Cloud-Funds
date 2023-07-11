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
    public class ProjectFundingsController : Controller
    {
        private readonly OurDbContext _context;

        public ProjectFundingsController(OurDbContext context)
        {
            _context = context;
        }

        // GET: ProjectFundings
        public async Task<IActionResult> Index()
        {
              return _context.ProjectFundings != null ? 
                          View(await _context.ProjectFundings.ToListAsync()) :
                          Problem("Entity set 'OurDbContext.ProjectFundings'  is null.");
        }

        // GET: ProjectFundings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectFundings == null)
            {
                return NotFound();
            }

            var projectFunding = await _context.ProjectFundings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectFunding == null)
            {
                return NotFound();
            }

            return View(projectFunding);
        }

        // GET: ProjectFundings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectFundings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AmountContributed")] ProjectFunding projectFunding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectFunding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectFunding);
        }

        // GET: ProjectFundings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectFundings == null)
            {
                return NotFound();
            }

            var projectFunding = await _context.ProjectFundings.FindAsync(id);
            if (projectFunding == null)
            {
                return NotFound();
            }
            return View(projectFunding);
        }

        // POST: ProjectFundings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AmountContributed")] ProjectFunding projectFunding)
        {
            if (id != projectFunding.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectFunding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectFundingExists(projectFunding.Id))
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
            return View(projectFunding);
        }

        // GET: ProjectFundings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectFundings == null)
            {
                return NotFound();
            }

            var projectFunding = await _context.ProjectFundings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectFunding == null)
            {
                return NotFound();
            }

            return View(projectFunding);
        }

        // POST: ProjectFundings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectFundings == null)
            {
                return Problem("Entity set 'OurDbContext.ProjectFundings'  is null.");
            }
            var projectFunding = await _context.ProjectFundings.FindAsync(id);
            if (projectFunding != null)
            {
                _context.ProjectFundings.Remove(projectFunding);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectFundingExists(int id)
        {
          return (_context.ProjectFundings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
