using appPFE.data;
using appPFE.Dtos;
using appPFE.Modeles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/examenResp")]
    public class ExamenRespController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;


        public ExamenRespController(AppDbContext appDbContext, IMapper mapper)
        {
            this._appDbContext = appDbContext;
            this._mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAlExamenResp()
        {
            var examenRespiratoire = await _appDbContext.ExamenRespiratoire.ToArrayAsync();
            return Ok(examenRespiratoire);
        }

        [HttpPost("addExamResp/{id_examResp:int}")]
        public async Task<IActionResult> AddExamResp(int id_examResp, [FromBody] ExamenRespiratoire examenRespiratoire)
        {
            // Check if the patient with the given Ipp exists
            var patient = await _appDbContext.ExamenCliniques.FindAsync(id_examResp);
            if (patient == null)
            {
                return NotFound($"Exam with id_exam {id_examResp} not found.");
            }

            // Ensure the Ipp is assigned to the examenClinique
            examenRespiratoire.respId = id_examResp;

            try
            {
                _appDbContext.ExamenRespiratoire.Add(examenRespiratoire);
                await _appDbContext.SaveChangesAsync();
                return Ok(examenRespiratoire);
            }
            catch (DbUpdateException ex)
            {
                // Log the error and return a bad request with the error details
                Console.WriteLine($"Error saving examen clinique: {ex.Message}");
                return BadRequest("An error occurred while saving the examen clinique. Please try again.");
            }
        }


        [HttpPut("{id_examResp}")]
        public async Task<IActionResult> UpdateExamResp(int id_examResp, ExamenRespiratoire examenResp)
        {

            var examenRespiratoire = await _appDbContext.ExamenRespiratoire.FindAsync(id_examResp);
            if (examenRespiratoire == null)
                return NotFound();

            // Update the existing entity with the values from the updated entity
            _appDbContext.Entry(examenRespiratoire).CurrentValues.SetValues(examenResp);

            // Save changes
            await _appDbContext.SaveChangesAsync();

            // Return the updated entity
            return Ok(examenRespiratoire);
        }





        [HttpDelete("{id_examResp}")]
        public async Task<IActionResult> DeleteExamenResp(int id_examResp)
        {
            var examenRespiratoire = await _appDbContext.ExamenRespiratoire.FindAsync(id_examResp);
            if (examenRespiratoire == null)
                return NotFound("examenRespiratoire not found");

            _appDbContext.Remove(examenRespiratoire);
            await _appDbContext.SaveChangesAsync();

            return Ok("examenRespiratoire deleted successfully");
        }


    }

}
