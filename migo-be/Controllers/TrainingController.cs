using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alliance_API.Data;
using Alliance_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using migo_be.Dto;
using migo_be.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace migo_be.Controllers
{
    [Route("api/[controller]")]
    public class TrainingController : Controller
    {
        private readonly DataContext _context;

        public TrainingController(DataContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<Training>>> GetTrainings()
        {
            var trainings = await _context.Trainings
                .Include(e => e.Employees)
                .ToListAsync();
            return trainings;
        }
        [HttpPost]
        public async Task<ActionResult<List<Training>>> AddTraining(TrainingDto request)
        {

            Training training = new Training();
            training.Name = request.Name;
            training.Url = request.Url;
            training.Category = request.Category;
            training.Aspects = request.Aspects;
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }
        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

