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
    public class ProjectFundingsApiController : ControllerBase
    {
        private readonly OurDbContext _context;

        public ProjectFundingsApiController(OurDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectFundingsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectFunding>>> GetProjectFundings()
        {
          if (_context.ProjectFundings == null)
          {
              return NotFound();
          }
            return await _context.ProjectFundings.ToListAsync();
        }

        // GET: api/ProjectFundingsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectFunding>> GetProjectFunding(int id)
        {
          if (_context.ProjectFundings == null)
          {
              return NotFound();
          }
            var projectFunding = await _context.ProjectFundings.FindAsync(id);

            if (projectFunding == null)
            {
                return NotFound();
            }

            return projectFunding;
        }
    }
}
