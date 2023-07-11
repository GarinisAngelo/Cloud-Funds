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
    public class ProjectPhotosController : Controller
    {
        private readonly OurDbContext _context;

        public ProjectPhotosController(OurDbContext context)
        {
            _context = context;
        }

        // GET: ProjectPhotos
        public async Task<IActionResult> Index()
        {
              return _context.ProjectPhotos != null ? 
                          View(await _context.ProjectPhotos.ToListAsync()) :
                          Problem("Entity set 'OurDbContext.ProjectPhotos'  is null.");
        }

        // GET: ProjectPhotos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectPhotos == null)
            {
                return NotFound();
            }

            var projectPhotos = await _context.ProjectPhotos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectPhotos == null)
            {
                return NotFound();
            }

            return View(projectPhotos);
        }

        // GET: ProjectPhotos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectPhotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PhotoName,PhotoDescription")] ProjectPhotos projectPhotos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectPhotos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectPhotos);
        }

        // GET: ProjectPhotos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectPhotos == null)
            {
                return NotFound();
            }

            var projectPhotos = await _context.ProjectPhotos.FindAsync(id);
            if (projectPhotos == null)
            {
                return NotFound();
            }
            return View(projectPhotos);
        }

        // POST: ProjectPhotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PhotoName,PhotoDescription")] ProjectPhotos projectPhotos)
        {
            if (id != projectPhotos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectPhotos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectPhotosExists(projectPhotos.Id))
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
            return View(projectPhotos);
        }

        // GET: ProjectPhotos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectPhotos == null)
            {
                return NotFound();
            }

            var projectPhotos = await _context.ProjectPhotos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectPhotos == null)
            {
                return NotFound();
            }

            return View(projectPhotos);
        }

        // POST: ProjectPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectPhotos == null)
            {
                return Problem("Entity set 'OurDbContext.ProjectPhotos'  is null.");
            }
            var projectPhotos = await _context.ProjectPhotos.FindAsync(id);
            if (projectPhotos != null)
            {
                _context.ProjectPhotos.Remove(projectPhotos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectPhotosExists(int id)
        {
          return (_context.ProjectPhotos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
