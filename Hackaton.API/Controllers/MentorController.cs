using Hackaton.API.Data;
using Hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Hackaton.API.Controllers
{
    [ApiController]
    [Route("/api/mentors")]
    public class MentorController : Controller
    {
        private readonly DataContext _context;

        public MentorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _context.Mentors.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var mentor = await _context.Mentors.FirstOrDefaultAsync(x => x.Id == id);
            if (mentor == null)
            {
                return NotFound();
            }
            return Ok(mentor);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Mentor mentor)
        {
            _context.Mentors.Add(mentor);
            await _context.SaveChangesAsync();
            return Ok(mentor);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Mentor mentor)
        {
            _context.Mentors.Update(mentor);
            await _context.SaveChangesAsync();
            return Ok(mentor);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Mentors
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

