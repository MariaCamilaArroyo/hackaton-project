using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackaton.API.Data;
using Hackaton.shared.Entities;

namespace Hackaton.API.Controllers
{
    [ApiController]
    [Route("/api/participants")]
    public class ParticipanteController : ControllerBase
    {
        private readonly DataContext _context;

        public ParticipanteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _context.Participantes.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var participante = await _context.Participantes.FirstOrDefaultAsync(x => x.Id == id);
            if (participante == null)
            {
                return NotFound();
            }
            return Ok(participante);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Participante participante)
        {
            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();
            return Ok(participante);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Participante participante)
        {
            _context.Participantes.Update(participante);
            await _context.SaveChangesAsync();
            return Ok(participante);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Participantes
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