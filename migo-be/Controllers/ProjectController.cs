using System;
using Alliance_API.Data;
using Alliance_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alliance_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjectController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetProjects()
        {
            var projects = await _context.Projects
                .Include(e => e.AssignedEmployees)
                .ToListAsync();
            return projects;
        }
        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeTimeLogs(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            _context.Entry(project).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteEmployeeTimeLog(int id)
        {
            var proj = await _context.Projects.FindAsync(id);
            if (proj == null)
            {
                return BadRequest("Employee Time Log not found");
            }
            _context.Projects.Remove(proj);
            await _context.SaveChangesAsync();
            return Ok(await _context.Projects.ToListAsync());
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}


