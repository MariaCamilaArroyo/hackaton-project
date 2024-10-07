using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackaton.API.Data;
using Hackaton.shared.Entities;

namespace Hackaton.API.Controllers
{
    [ApiController]
    [Route("/api/hackatons")]
    public class HackatonTableController : ControllerBase
    {
        private readonly DataContext _context;

        public HackatonTableController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _context.Hackatons.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var hackaton = await _context.Hackatons.FirstOrDefaultAsync(x => x.Id == id);
            if (hackaton == null)
            {
                return NotFound();
            }
            return Ok(hackaton);
        }

        [HttpPost]
        public async Task<ActionResult> Create(HackatonTable hackaton)
        {
            _context.Hackatons.Add(hackaton);
            await _context.SaveChangesAsync();
            return Ok(hackaton);
        }

        [HttpPut]
        public async Task<ActionResult> Update(HackatonTable hackaton)
        {
            _context.Hackatons.Update(hackaton);
            await _context.SaveChangesAsync();
            return Ok(hackaton);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Hackatons
                .Where(h => h.Id == id)
                .ExecuteDeleteAsync();

            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}