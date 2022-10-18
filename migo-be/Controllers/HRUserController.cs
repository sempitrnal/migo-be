using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alliance_API.Data;
using Alliance_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alliance_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HRUserController : ControllerBase
    {
        private readonly DataContext _context;

        public HRUserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HRUser>>> GetHR()
        {
            var hRUsers = await _context.HRUsers.ToListAsync();

            return hRUsers;
        }

    }
}

