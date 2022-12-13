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
        private readonly IWebHostEnvironment _hostEnvironment;
        public BenefitsController(DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<List<Benefits>>> GetBenefits()
        {
            var projects = await _context.Benefits
                .Select(x => new Benefits()
                {
                    Id=x.Id,
                    Description= x.Description,
                    BenefitType=x.BenefitType,
                    Duration=x.Duration,
                    Name  = x.Name,
                    ImageFile= x.ImageFile,
                    ImageName = x.ImageName,
                    ImageSrc= String.Format("{0}://{1}{2}/Images/Benefits/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageName)

                })
                .ToListAsync();
            return projects;
        }

        [HttpPost]
        public async Task<ActionResult<List<Benefits>>> AddBenefits(Benefits benefit)
        {
            benefit.ImageName =  await SaveImage(benefit.ImageFile, benefit.ImageSrc);
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
            if (benefit.ImageFile != null)
            {
                DeleteImage(benefit.ImageName);
                benefit.ImageName = await SaveImage(benefit.ImageFile, benefit.Name);
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

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile, string name)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = name + "-" + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images/Benefits", imageName);
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
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images/Benefits", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}
