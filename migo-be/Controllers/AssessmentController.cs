using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alliance_API.Data;
using Alliance_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using migo_be.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace migo_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController : Controller
    {
        private readonly DataContext _context;


        public AssessmentController(DataContext context)
        {
            _context = context;
        }




        //[HttpGet]
        //public async Task<ActionResult<List<Assessment>>> GetAssessments()
        //{
        //    var assessments = await _context.Assessments
        //        .Include(c => c.Employee)
        //        .Include(c => c.Quality)
        //       .Include(c => c.Innovation)
        //        .Include(c => c.Agility)
        //        .Include(c => c.Integrity)
        //        .Include(c => c.FunctionalComponents)
        //        .Include(c => c.Performance)
        //        .ToListAsync();
        //    return assessments;
        //}
        //int empId, AssessmentDto request
        [HttpPost]
        public async Task<ActionResult<List<Assessment>>> AddAssessment(int empId, AssessmentDto request)
        {
            var employee = await _context.Employees.FindAsync(empId);
            if (employee == null)
                return BadRequest("Employee not found");

            Assessment assessment = new Assessment();
            assessment.Employee = employee;
            assessment.Quality = request.Quality;
            assessment.Innovation = request.Innovation;
            assessment.Agility = request.Agility;
            assessment.Efficiency = request.Efficiency;
            assessment.Integrity = request.Integrity;
            assessment.FunctionalComponents = request.FunctionalComponents;
            assessment.Performance = request.Performance;
            
            _context.Assessments.Add(assessment);
            await _context.SaveChangesAsync();

            return Ok(await _context.Assessments.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Assessment>>> GetAssessmentsById(int empId)
        {
            var ass = await _context.Assessments.Where(e => e.EmployeeId == empId)
                .Include(c => c.Quality)
               .Include(c => c.Innovation)
                .Include(c => c.Agility)
                .Include(c => c.Integrity)
                 .Include(c => c.Efficiency)
                .Include(c => c.FunctionalComponents)
                .Include(c => c.Performance).ToListAsync();
            return ass;
        }
    }
}

