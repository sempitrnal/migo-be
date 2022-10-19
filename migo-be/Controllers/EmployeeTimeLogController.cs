using Alliance_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using migo_be.Models;

namespace migo_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTimeLogController : ControllerBase
    {
        public readonly DataContext _context;

        public EmployeeTimeLogController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<EmployeeTimeLogs>>> GetTimeLogsById(int empId)
        {
            var logs = await _context.EmployeeTimeLogs.Where(e => e.EmployeeId == empId).ToListAsync();
            return logs;
        }

        [HttpPost]
        public async Task<ActionResult<List<EmployeeTimeLogs>>> AddTimeLog(int empId, EmployeeTimeLogDto request)
        {
            var employee = await _context.Employees.FindAsync(empId);
            if (employee == null)
                return BadRequest("Employee not found");
            
            EmployeeTimeLogs employeeTimeLogs = new EmployeeTimeLogs();
            employeeTimeLogs.Action = request.Action;
            employeeTimeLogs.Employee = employee;
            employeeTimeLogs.EmployeeId = empId;
            employeeTimeLogs.Time = request.Time;
            employeeTimeLogs.Remark = request.Remark;   

            _context.EmployeeTimeLogs.Add(employeeTimeLogs);
            await _context.SaveChangesAsync();
            return Ok(_context.EmployeeTimeLogs.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeTimeLogs(int id, EmployeeTimeLogs log)
        {
            if (id != log.Id)
            {
                return BadRequest();
            }
            _context.EmployeeTimeLogs.Update(log);
            await _context.SaveChangesAsync();
            _context.Entry(log).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTimeLogsExists(id))
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
        public async Task<ActionResult<EmployeeTimeLogs>> DeleteEmployeeTimeLog(int id)
        {
            var log = await _context.EmployeeTimeLogs.FindAsync(id);
            if (log == null)
            {
                return BadRequest("Employee Time Log not found");
            }
            _context.EmployeeTimeLogs.Remove(log);
            await _context.SaveChangesAsync();
            return Ok(await _context.EmployeeTimeLogs.ToListAsync());
        }

        private bool EmployeeTimeLogsExists(int id)
        {
            return _context.EmployeeTimeLogs.Any(e => e.Id == id);
        }
    }
}
