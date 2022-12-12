using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Alliance_API.Models;
using migo_be.Models;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Alliance_API.Data;
using Microsoft.EntityFrameworkCore;

namespace migo_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        
        
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HRUser>>> GetHRUsers()
        {
            var hrusers = await _context.HRUsers.ToListAsync();

            return hrusers;

        }
        [HttpPost("register")]
        public async Task<ActionResult<HRUser>> Register(HRUserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            HRUser user = new HRUser();
            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.HRUsers.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.HRUsers.ToListAsync());
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(HRUserDto request)
        {
            var hr = await _context.HRUsers.FirstOrDefaultAsync(e=>e.Username == request.Username);
            if(hr == null)
            {
                return BadRequest("User not found");
            }
           
            //if (user.Username != request.Username)
            //{
            //    return BadRequest("User not found");
            //}
            if (!VerifyPasswordHash (hr,request.Password, hr.PasswordHash, hr.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(hr);
            return Ok(token);
        }

        private string CreateToken(HRUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(HRUser hr, string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(hr.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
