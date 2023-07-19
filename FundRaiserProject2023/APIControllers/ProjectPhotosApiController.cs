using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FundRaiserProject2023.DbContexts;
using FundRaiserProject2023.Models;

namespace FundRaiserProject2023.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectPhotosApiController : ControllerBase
    {
        private readonly OurDbContext _context;

        public ProjectPhotosApiController(OurDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectPhotosApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectPhotos>>> GetProjectPhotos()
        {
          if (_context.ProjectPhotos == null)
          {
              return NotFound();
          }
            return await _context.ProjectPhotos.ToListAsync();
        }

        // GET: api/ProjectPhotosApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectPhotos>> GetProjectPhotos(int id)
        {
          if (_context.ProjectPhotos == null)
          {
              return NotFound();
          }
            var projectPhotos = await _context.ProjectPhotos.FindAsync(id);

            if (projectPhotos == null)
            {
                return NotFound();
            }

            return projectPhotos;
        }
    }
}
