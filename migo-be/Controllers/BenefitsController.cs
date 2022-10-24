using Alliance_API.Data;
using Alliance_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace migo_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitsController : ControllerBase
    {
        private readonly DataContext _context;

        public BenefitsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Benefits>>> GetBenefits()
        {
            var projects = await _context.Benefits
                .ToListAsync();
            return projects;
        }

        [HttpPost]
        public async Task<ActionResult<List<Benefits>>> AddBenefits(Benefits benefit)
        {
            _context.Benefits.Add(benefit);
            await _context.SaveChangesAsync();

            return Ok(await _context.Benefits.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBenefits(int id, Benefits benefit)
        {
            if (id != benefit.Id)
            {
                return BadRequest();
            }
            _context.Benefits.Update(benefit);
            await _context.SaveChangesAsync();
            _context.Entry(benefit).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenefitExists(id))
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
        public async Task<ActionResult<Benefits>> DeleteEmployeeTimeLog(int id)
        {
            var proj = await _context.Benefits.FindAsync(id);
            if (proj == null)
            {
                return BadRequest("Benefit not found");
            }
            _context.Benefits.Remove(proj);
            await _context.SaveChangesAsync();
            return Ok(await _context.Benefits.ToListAsync());
        }

        private bool BenefitExists(int id)
        {
            return _context.Benefits.Any(e => e.Id == id);
        }
    }
}
