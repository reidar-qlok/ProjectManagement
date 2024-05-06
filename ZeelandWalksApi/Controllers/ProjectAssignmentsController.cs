using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Data;
using ProjectManagerApi.Models.Domain;

namespace ProjectManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAssignmentsController : ControllerBase
    {
        private readonly PMDbContext _context;

        public ProjectAssignmentsController(PMDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectAssignment>>> GetProjectAssignments()
        {
            return await _context.ProjectAssignments
                .Include(pa => pa.Employee)
                .Include(pa => pa.Project)
                .ToListAsync();
        }

        // GET: api/ProjectAssignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectAssignment>> GetProjectAssignment(int id)
        {
            var projectAssignment = await _context.ProjectAssignments
                .Include(pa => pa.Employee)
                .Include(pa => pa.Project)
                .FirstOrDefaultAsync(pa => pa.ProjectAssignmentId == id);

            if (projectAssignment == null)
            {
                return NotFound();
            }

            return projectAssignment;
        }

        // POST: api/ProjectAssignments
        [HttpPost]
        public async Task<ActionResult<ProjectAssignment>> PostProjectAssignment(ProjectAssignment projectAssignment)
        {
            _context.ProjectAssignments.Add(projectAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectAssignment", new { id = projectAssignment.ProjectAssignmentId }, projectAssignment);
        }

        // PUT: api/ProjectAssignments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectAssignment(int id, ProjectAssignment projectAssignment)
        {
            if (id != projectAssignment.ProjectAssignmentId)
            {
                return BadRequest();
            }

            _context.Entry(projectAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectAssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ProjectAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAssignment(int id)
        {
            var projectAssignment = await _context.ProjectAssignments.FindAsync(id);
            if (projectAssignment == null)
            {
                return NotFound();
            }

            _context.ProjectAssignments.Remove(projectAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectAssignmentExists(int id)
        {
            return _context.ProjectAssignments.Any(e => e.ProjectAssignmentId == id);
        }
    }
}
