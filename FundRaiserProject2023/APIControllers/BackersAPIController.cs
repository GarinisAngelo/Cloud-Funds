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
    public class BackersAPIController : ControllerBase
    {
        private readonly OurDbContext _context;

        public BackersAPIController(OurDbContext context)
        {
            _context = context;
        }

        // GET: api/BackersAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Backer>>> GetBackers()
        {
          if (_context.Backers == null)
          {
              return NotFound();
          }
            return await _context.Backers.ToListAsync();
        }

        // GET: api/BackersAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Backer>> GetBacker(int id)
        {
          if (_context.Backers == null)
          {
              return NotFound();
          }
            var backer = await _context.Backers.FindAsync(id);

            if (backer == null)
            {
                return NotFound();
            }

            return backer;
        }
    }
}
