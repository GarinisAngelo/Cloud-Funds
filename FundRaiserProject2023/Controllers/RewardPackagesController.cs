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
    public class RewardPackagesController : Controller
    {
        private readonly OurDbContext _context;

        public RewardPackagesController(OurDbContext context)
        {
            _context = context;
        }

        // GET: RewardPackages
        public async Task<IActionResult> Index()
        {
              return _context.RewardPackages != null ? 
                          View(await _context.RewardPackages.ToListAsync()) :
                          Problem("Entity set 'OurDbContext.RewardPackages'  is null.");
        }

        // GET: RewardPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RewardPackages == null)
            {
                return NotFound();
            }

            var rewardPackage = await _context.RewardPackages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rewardPackage == null)
            {
                return NotFound();
            }

            return View(rewardPackage);
        }

        // GET: RewardPackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RewardPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PackageName,PackageAmount,RewardDescription")] RewardPackage rewardPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rewardPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rewardPackage);
        }

        // GET: RewardPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RewardPackages == null)
            {
                return NotFound();
            }

            var rewardPackage = await _context.RewardPackages.FindAsync(id);
            if (rewardPackage == null)
            {
                return NotFound();
            }
            return View(rewardPackage);
        }

        // POST: RewardPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PackageName,PackageAmount,RewardDescription")] RewardPackage rewardPackage)
        {
            if (id != rewardPackage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rewardPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RewardPackageExists(rewardPackage.Id))
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
            return View(rewardPackage);
        }

        // GET: RewardPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RewardPackages == null)
            {
                return NotFound();
            }

            var rewardPackage = await _context.RewardPackages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rewardPackage == null)
            {
                return NotFound();
            }

            return View(rewardPackage);
        }

        // POST: RewardPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RewardPackages == null)
            {
                return Problem("Entity set 'OurDbContext.RewardPackages'  is null.");
            }
            var rewardPackage = await _context.RewardPackages.FindAsync(id);
            if (rewardPackage != null)
            {
                _context.RewardPackages.Remove(rewardPackage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RewardPackageExists(int id)
        {
          return (_context.RewardPackages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
