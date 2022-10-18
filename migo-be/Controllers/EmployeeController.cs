using System;
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

        public EmployeeController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees
                .Include(c => c.AssignedProjects)
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
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
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
    }
}

