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
    public class ProjectCreatorsApiController : ControllerBase
    {
        private readonly OurDbContext _context;

        public ProjectCreatorsApiController(OurDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectCreatorsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectCreator>>> GetProjectCreators()
        {
          if (_context.ProjectCreators == null)
          {
              return NotFound();
          }
            return await _context.ProjectCreators.ToListAsync();
        }

        // GET: api/ProjectCreatorsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectCreator>> GetProjectCreator(int id)
        {
          if (_context.ProjectCreators == null)
          {
              return NotFound();
          }
            var projectCreator = await _context.ProjectCreators.FindAsync(id);

            if (projectCreator == null)
            {
                return NotFound();
            }

            return projectCreator;
        }
    }
}
