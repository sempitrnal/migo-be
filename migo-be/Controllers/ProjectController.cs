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

    }
}

