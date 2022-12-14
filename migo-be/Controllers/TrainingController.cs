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
        private readonly IWebHostEnvironment _hostEnvironment;
        public TrainingController(DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<Training>>> GetTrainings()
        {
            var trainings = await _context.Trainings
                .Select(x=> new Training()
                {
                    Id=x.Id,
                    Aspects=x.Aspects,
                    Category=x.Category,
                    Employees = x.Employees,
                    Name=x.Name,
                    Url=x.Url,
                    ImageFile=x.ImageFile,
                    ImageName=x.ImageName,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/Trainings/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageName)
                })
                .ToListAsync();
            return trainings;
        }
        [HttpPost]
        public async Task<ActionResult<List<Training>>> AddTraining([FromForm]Training training)
        {

            training.ImageName = await SaveImage(training.ImageFile, training.ImageSrc);
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }
        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile, string name)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = name + "-" + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images/Trainings", imageName);
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
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images/Trainings", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}

