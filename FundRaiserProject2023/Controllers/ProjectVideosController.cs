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
    public class ProjectVideosController : Controller
    {
        private readonly OurDbContext _context;

        public ProjectVideosController(OurDbContext context)
        {
            _context = context;
        }

        // GET: ProjectVideos
        public async Task<IActionResult> Index()
        {
              return _context.ProjectVideos != null ? 
                          View(await _context.ProjectVideos.ToListAsync()) :
                          Problem("Entity set 'OurDbContext.ProjectVideos'  is null.");
        }

        // GET: ProjectVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectVideos == null)
            {
                return NotFound();
            }

            var projectVideos = await _context.ProjectVideos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectVideos == null)
            {
                return NotFound();
            }

            return View(projectVideos);
        }

        // GET: ProjectVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectVideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VideoName,VideoDescription")] ProjectVideos projectVideos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectVideos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectVideos);
        }

        // GET: ProjectVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectVideos == null)
            {
                return NotFound();
            }

            var projectVideos = await _context.ProjectVideos.FindAsync(id);
            if (projectVideos == null)
            {
                return NotFound();
            }
            return View(projectVideos);
        }

        // POST: ProjectVideos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VideoName,VideoDescription")] ProjectVideos projectVideos)
        {
            if (id != projectVideos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectVideos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectVideosExists(projectVideos.Id))
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
            return View(projectVideos);
        }

        // GET: ProjectVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectVideos == null)
            {
                return NotFound();
            }

            var projectVideos = await _context.ProjectVideos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectVideos == null)
            {
                return NotFound();
            }

            return View(projectVideos);
        }

        // POST: ProjectVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectVideos == null)
            {
                return Problem("Entity set 'OurDbContext.ProjectVideos'  is null.");
            }
            var projectVideos = await _context.ProjectVideos.FindAsync(id);
            if (projectVideos != null)
            {
                _context.ProjectVideos.Remove(projectVideos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectVideosExists(int id)
        {
          return (_context.ProjectVideos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
