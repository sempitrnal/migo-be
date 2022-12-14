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
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProjectController(DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetProjects()
        {
            var projects = await _context.Projects
                .Select(x => new Project()
                {
                    Id = x.Id,
                    Name = x.Name,
                    AssignedEmployees=x.AssignedEmployees,
                    ClientName= x.ClientName,
                    Deadline = x.Deadline,
                    Description=x.Description,
                    ImageName=x.ImageName,
                    ImageFile=x.ImageFile,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/Projects/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageName)

                }).ToListAsync();
             
            return projects;
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject([FromForm] Project project)
        {
            Console.WriteLine(project.ImageFile);

            project.ImageName = await SaveImage(project.ImageFile, project.Name);
            
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return Ok(await _context.Projects.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }
            if (project.ImageFile != null)
            {
                DeleteImage(project.ImageName);
                project.ImageName = await SaveImage(project.ImageFile, project.Name);
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

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile, string name)
        {
            
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = name + "-" + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images/Projects", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            Console.WriteLine(imageName);
            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images/Projects", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}


