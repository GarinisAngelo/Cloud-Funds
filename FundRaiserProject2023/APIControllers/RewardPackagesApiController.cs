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
    public class RewardPackagesApiController : ControllerBase
    {
        private readonly OurDbContext _context;

        public RewardPackagesApiController(OurDbContext context)
        {
            _context = context;
        }

        // GET: api/RewardPackagesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RewardPackage>>> GetRewardPackages()
        {
          if (_context.RewardPackages == null)
          {
              return NotFound();
          }
            return await _context.RewardPackages.ToListAsync();
        }

        // GET: api/RewardPackagesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RewardPackage>> GetRewardPackage(int id)
        {
          if (_context.RewardPackages == null)
          {
              return NotFound();
          }
            var rewardPackage = await _context.RewardPackages.FindAsync(id);

            if (rewardPackage == null)
            {
                return NotFound();
            }

            return rewardPackage;
        }
    }
}
