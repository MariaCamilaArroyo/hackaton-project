using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackaton.API.Data;
using Hackaton.shared.Entities;

namespace Hackaton.API.Controllers
{
    [ApiController]
    [Route("/api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjectController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _context.Projects.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return Ok(project);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return Ok(project);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Projects
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