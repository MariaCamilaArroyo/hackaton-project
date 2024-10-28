using Hackaton.API.Data;
using Hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Hackaton.API.Controllers
{

    [ApiController]
    [Route("/api/evaluations")]
    public class EvaluationController : Controller
    {
        private readonly DataContext _context;

        public EvaluationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            return Ok(await _context.Evaluations.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var Evaluation = await _context.Evaluations.FirstOrDefaultAsync(x => x.Id == id);
            if (Evaluation == null)
            {
                return NotFound();
            }
            return Ok(Evaluation);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Evaluation evaluation)
        {
            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync();
            return Ok(evaluation);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Evaluation evaluation)
        {
            _context.Evaluations.Update(evaluation);
            await _context.SaveChangesAsync();
            return Ok(evaluation);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Evaluations
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

