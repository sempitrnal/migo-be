using System;
using Alliance_API.Data;
using Alliance_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using migo_be.Models;

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
        public async Task<ActionResult<List<Project>>> AddProject(ProjectDto request)
        {
     

            Project project = new Project();
            project.Name = request.Name;
            project.ClientName = request.ClientName;
            project.Deadline = request.Deadline;
            project.Description = request.Description;
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



        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}


