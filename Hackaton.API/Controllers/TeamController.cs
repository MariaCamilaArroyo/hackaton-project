using Hackaton.API.Data;
using Hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Hackaton.API.Controllers
{
    [ApiController]
    [Route("/api/teams")]
    public class TeamController : Controller
    {
        private readonly DataContext _context;

        public TeamController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _context.Teams.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return Ok(team);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return Ok(team);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Teams
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();

            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
