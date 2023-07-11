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
    public class ProjectCreatorsController : Controller
    {
        private readonly OurDbContext _context;

        public ProjectCreatorsController(OurDbContext context)
        {
            _context = context;
        }

        // GET: ProjectCreators
        public async Task<IActionResult> Index()
        {
            var ourDbContext = _context.ProjectCreators.Include(p => p.User);
            return View(await ourDbContext.ToListAsync());
        }

        // GET: ProjectCreators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectCreators == null)
            {
                return NotFound();
            }

            var projectCreator = await _context.ProjectCreators
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectCreator == null)
            {
                return NotFound();
            }

            return View(projectCreator);
        }

        // GET: ProjectCreators/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ProjectCreators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ProjectCreator projectCreator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectCreator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", projectCreator.Id);
            return View(projectCreator);
        }

        // GET: ProjectCreators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectCreators == null)
            {
                return NotFound();
            }

            var projectCreator = await _context.ProjectCreators.FindAsync(id);
            if (projectCreator == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", projectCreator.Id);
            return View(projectCreator);
        }

        // POST: ProjectCreators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ProjectCreator projectCreator)
        {
            if (id != projectCreator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectCreator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectCreatorExists(projectCreator.Id))
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
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", projectCreator.Id);
            return View(projectCreator);
        }

        // GET: ProjectCreators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectCreators == null)
            {
                return NotFound();
            }

            var projectCreator = await _context.ProjectCreators
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectCreator == null)
            {
                return NotFound();
            }

            return View(projectCreator);
        }

        // POST: ProjectCreators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectCreators == null)
            {
                return Problem("Entity set 'OurDbContext.ProjectCreators'  is null.");
            }
            var projectCreator = await _context.ProjectCreators.FindAsync(id);
            if (projectCreator != null)
            {
                _context.ProjectCreators.Remove(projectCreator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectCreatorExists(int id)
        {
          return (_context.ProjectCreators?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
