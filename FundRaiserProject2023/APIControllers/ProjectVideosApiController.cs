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
    public class ProjectVideosApiController : ControllerBase
    {
        private readonly OurDbContext _context;

        public ProjectVideosApiController(OurDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectVideosApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectVideos>>> GetProjectVideos()
        {
          if (_context.ProjectVideos == null)
          {
              return NotFound();
          }
            return await _context.ProjectVideos.ToListAsync();
        }

        // GET: api/ProjectVideosApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectVideos>> GetProjectVideos(int id)
        {
          if (_context.ProjectVideos == null)
          {
              return NotFound();
          }
            var projectVideos = await _context.ProjectVideos.FindAsync(id);

            if (projectVideos == null)
            {
                return NotFound();
            }

            return projectVideos;
        }
    }
}
