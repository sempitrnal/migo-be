using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alliance_API.Data;
using Alliance_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using migo_be.Models;
using Migo_be;

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
            //Load sample data
            var quality = new MLModel.ModelInput()
            {
                Score = (float) (request.Quality.CA_Q1 + request.Quality.CA_Q2)/2,
            };

            //Load model and predict output
            var qualityResult = MLModel.Predict(quality);

            var innovation = new MLModel.ModelInput()
            {
                Score = (float)(request.Innovation.CA_Q1+ request.Innovation.CA_Q2) / 2,
            };

            //Load model and predict output
            var innovationResult = MLModel.Predict(innovation);

            var agility = new MLModel.ModelInput()
            {
                Score = (float)(request.Agility.CA_Q1 + request.Agility.CA_Q2 + request.Agility.CA_Q3) / 3,
            };

            //Load model and predict output
            var agilityResult = MLModel.Predict(innovation);

            var efficiency = new MLModel.ModelInput()
            {
                Score = (float)(request.Efficiency.CA_Q1+ request.Efficiency.CA_Q2+ request.Efficiency.CA_Q3) / 3,
            };

            //Load model and predict output
            var efficiencyResult = MLModel.Predict(efficiency);

            var integrity = new MLModel.ModelInput()
            {
                Score = (float)(request.Integrity.CA_Q1 + request.Integrity.CA_Q2 + request.Integrity.CA_Q3 + request.Integrity.CA_Q4) / 4,
            };

            //Load model and predict output
            var integrityResult = MLModel.Predict(integrity);

            var functionalComponents = new MLModel.ModelInput()
            {
                Score = (float)(request.FunctionalComponents.FC_PE_Q1 + request.FunctionalComponents.FC_EC_Q1 + request.FunctionalComponents.FC_TP_Q1 + request.FunctionalComponents.FC_KS_Q1 + request.FunctionalComponents.FC_LTS_Q1) / 5,
            };

            //Load model and predict output
            var functionalComponentsResult = MLModel.Predict(functionalComponents);

            var performance = new MLModel.ModelInput()
            {
                Score = (float)(request.Performance.P_D_Q1 + request.Performance.P_C_Q1 + request.Performance.P_E_Q1 + request.Performance.P_A_Q1 + request.Performance.P_B_Q1) / 5,
            };
            //Load model and predict output
            var performanceResult = MLModel.Predict(performance);

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(qualityResult.PredictedLabel.ToString() + "\n");
            Console.WriteLine(innovationResult.PredictedLabel.ToString() + "\n");
            Console.WriteLine(agilityResult.PredictedLabel.ToString() + "\n");
            Console.WriteLine(efficiencyResult.PredictedLabel.ToString() + "\n");
            Console.WriteLine(integrityResult.PredictedLabel.ToString() + "\n");
            Console.WriteLine(functionalComponentsResult.PredictedLabel.ToString() + "\n");
            Console.WriteLine(performanceResult.PredictedLabel.ToString() + "\n");

            //Load sample data
            var trainingAssessment = new TrainingsML.ModelInput()
            {
                Quality = qualityResult.PredictedLabel.ToString(),
                Efficiency = efficiencyResult.PredictedLabel.ToString(),
                Agility = agilityResult.PredictedLabel.ToString(),
                Innovation = innovationResult.PredictedLabel.ToString(),
                Integrity = integrityResult.PredictedLabel.ToString(),
                Functional_Components = functionalComponentsResult.PredictedLabel.ToString(),
                Performance = performanceResult.PredictedLabel.ToString(),
            };

            //Load model and predict output
            var trainingsAssessmentResult = TrainingsML.Predict(trainingAssessment);

            Assessment assessment = new Assessment();
            assessment.Employee = employee;
            assessment.Quality = request.Quality;
            assessment.Innovation = request.Innovation;
            assessment.Agility = request.Agility;
            assessment.Efficiency = request.Efficiency;
            assessment.Integrity = request.Integrity;
            assessment.FunctionalComponents = request.FunctionalComponents;
            assessment.Performance = request.Performance;

            //Remarks
            assessment.AgilityRemark = agilityResult.PredictedLabel.ToString();
            assessment.EfficiencyRemark = efficiencyResult.PredictedLabel.ToString();
            assessment.FunctionalComponentsRemark = functionalComponentsResult.PredictedLabel.ToString();
            assessment.InnovationRemark = innovationResult.PredictedLabel.ToString();
            assessment.IntegrityRemark = integrityResult.PredictedLabel.ToString();
            assessment.PerformanceRemark = performanceResult.PredictedLabel.ToString();
            assessment.QualityRemark = qualityResult.PredictedLabel.ToString();

            assessment.TrainingAssessment = trainingsAssessmentResult.PredictedLabel.ToString();
            assessment.has
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

