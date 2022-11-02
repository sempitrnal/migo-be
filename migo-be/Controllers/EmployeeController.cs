using System;
using System.Reflection.Metadata.Ecma335;
using Alliance_API.Data;
using Alliance_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alliance_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public EmployeeController(DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees
                .Include(c => c.AssignedProjects)
                .Include(c => c.EmployeeTimeLogs)
                 .Select(x => new Employee()
                 {
                     Id = x.Id,
                     FirstName = x.FirstName,
                     MiddleName = x.MiddleName,
                     LastName = x.LastName,
                     CityAddress = x.CityAddress,
                     CityContactNumber = x.CityContactNumber,
                     NumberOfDependents = x.NumberOfDependents,
                     CivicClubAffiliation = x.CivicClubAffiliation,
                     Religion = x.Religion,
                     Age = x.Age,
                     Sex = x.Sex,
                     CivilStatus = x.CivilStatus,
                     Birthdate = x.Birthdate,
                     Profession = x.Profession,
                     ContactNumber = x.ContactNumber,
                     EmailAddress = x.EmailAddress,
                     YearsOfExperience = x.YearsOfExperience,
                     ContractType = x.ContractType,
                     PositionApplied = x.PositionApplied,
                     PositionCode = x.PositionCode,
                     DateJoined = x.DateJoined,
                     EmergencyAddress = x.EmergencyAddress,
                     EmergencyContactNumber = x.EmergencyContactNumber,
                     EmergencyName = x.EmergencyName,
                     EmergencyRelationship = x.EmergencyRelationship,
                     Status = x.Status,
                     ImageName = x.ImageName,
                     AssignedProjects = x.AssignedProjects,
                     EmployeeTimeLogs = x.EmployeeTimeLogs,
                     BloodType = x.BloodType,
                     ImageFile = x.ImageFile,
                     ImageSrc = String.Format("{0}://{1}{2}/Images/Employees/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageName)
                 })
                .ToListAsync();

            return employees;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
            {
                return BadRequest("Employee not found");
            }

            return Ok(emp);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee([FromForm] Employee emp)
        {
            Console.WriteLine(emp.ImageFile);
            emp.ImageName = await SaveImage(emp.ImageFile, emp.FirstName, emp.LastName);
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromForm] Employee emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
            }
            if (emp.ImageFile != null)
            {
                DeleteImage(emp.ImageName);
                emp.ImageName = await SaveImage(emp.ImageFile, emp.FirstName, emp.LastName);
            }
            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
            _context.Entry(emp).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
            {
                return BadRequest("Employee not found");
            }
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile, string fn, string ln)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = fn+ln + "-"+ DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images/Employees", imageName);
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
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images/Employees", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}

