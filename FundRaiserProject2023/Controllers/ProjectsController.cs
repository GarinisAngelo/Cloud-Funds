using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FundRaiserProject2023.DbContexts;
using FundRaiserProject2023.Models;
using System.Diagnostics.Eventing.Reader;
using FundRaiserProject2023.Services;

namespace FundRaiserProject2023.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly OurDbContext _context;
        private readonly IProjectService _services;

        public ProjectsController(OurDbContext context, IProjectService services)
        {
            _context = context;
            _services = services;
        }

        public IActionResult FundedProjects()
        {
            if (_context.Projects == null)
            {
                return NotFound();
            }

            var projectQuery = _context.Projects
                                .Join(_context.ProjectFundings,
                                project => project.Id,
                                funding => funding.Projects.Id,
                                (project, funding) => new Project
                                {
                                    Title = project.Title,
                                    Description = project.Description,
                                    FundingGoal = project.FundingGoal,
                                    CurrentFunding = project.CurrentFunding
                                })
                            .Distinct()
                            .ToList();
            if (projectQuery == null)
            {
                return NotFound();
            }

            return View(projectQuery);
        }

        public IActionResult BackerProjects()
        {
            return View(_context.Projects.Include("ProjectPhotos").Include("ProjectVideos").Include("ProjectCreator").Include("RewardPackages").ToList());
        }

        public async Task<IActionResult> BackerDetails(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.Include("ProjectPhotos").Include("ProjectVideos").Include("ProjectCreator").Include("RewardPackages")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public async Task<IActionResult> FundThisProject(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.Include("ProjectPhotos").Include("ProjectVideos").Include("ProjectCreator").Include("RewardPackages")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
              return _context.Projects != null ? 
                          View(await _context.Projects.ToListAsync()) :
                          Problem("Entity set 'OurDbContext.Projects'  is null.");
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.Include("ProjectPhotos").Include("ProjectVideos").Include("ProjectCreator").Include("RewardPackages")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();

                if (project.ProjectPhotos != null)
                {
                    foreach(var photo in project.ProjectPhotos)
                    {
                        _context.ProjectPhotos.Add(photo);
                        await _context.SaveChangesAsync();
                    }
                }

                if (project.ProjectVideos != null)
                {
                    foreach (var video in project.ProjectVideos)
                    {
                        _context.ProjectVideos.Add(video);
                        await _context.SaveChangesAsync();
                    }
                }

                if (project.RewardPackages != null)
                {
                    foreach (var rp in project.RewardPackages)
                    {
                        _context.Projects.Update(project);
                        await _context.SaveChangesAsync();
                    }
                }

                if (project.ProjectCreator != null)
                {
                    /*var creator = _context.ProjectCreators.Find(project.ProjectCreator.Id);
                    project.ProjectCreator = creator;*/
                    _context.Projects.Update(project);
                    await _context.SaveChangesAsync();                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,FundingGoal,CurrentFunding")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projects == null)
            {
                return Problem("Entity set 'OurDbContext.Projects'  is null.");
            }
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
          return (_context.Projects?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]

        public IActionResult InsertFunding([Bind("PackageAmount")] decimal PackageAmount,
            [Bind("ProjectId")] int ProjectId, 
            [Bind("BackerId")] int BackerId)
        {
            ProjectFunding projectFunding = new ProjectFunding()
            {
                Backer = _context.Backers.Find(BackerId),
                Date = DateTime.Now,
                Projects = _context.Projects.Find(ProjectId),
                AmountContributed = PackageAmount
            };

            var project = _context.Projects.Find(ProjectId);            
            var newCurrentFund = PackageAmount + project.CurrentFunding;
            if(project.FundingGoal >= newCurrentFund)
            {
                project.CurrentFunding = newCurrentFund;
            }
            else
            {
                project.CurrentFunding = project.FundingGoal;
            }            
            _context.ProjectFundings.Add(projectFunding);
            _context.SaveChanges();

            return RedirectToAction("BackerProjects", "Projects");

        }
    }
}
