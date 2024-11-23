using appPFE.data;
using appPFE.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/examenUro")]
    public class ExamenUroController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ExamenUroController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExamenUro()
        {
            var aspectGeneral = await _appDbContext.ExamenUroGenital.ToListAsync();
            return Ok(aspectGeneral);
        }
    
        [HttpPost("addExamUro/{Id_exam:int}")]
        public async Task<IActionResult> AddExamUro(int Id_exam, [FromBody] ExamenUroGenital examenUroGenital)
        {
            // Check if the patient with the given Ipp exists
            var patient = await _appDbContext.ExamenCliniques.FindAsync(Id_exam);
            if (patient == null)
            {
                return NotFound($"Exam with id_exam {Id_exam} not found.");
            }

            // Ensure the Ipp is assigned to the examenClinique
            examenUroGenital.examId = Id_exam;

            try
            {
                _appDbContext.ExamenUroGenital.Add(examenUroGenital);
                await _appDbContext.SaveChangesAsync();
                return Ok(examenUroGenital);
            }
            catch (DbUpdateException ex)
            {
                // Log the error and return a bad request with the error details
                Console.WriteLine($"Error saving examen clinique: {ex.Message}");
                return BadRequest("An error occurred while saving the examen clinique. Please try again.");
            }
        }

        [HttpGet("{id_examUG:int}")]
        public async Task<IActionResult> GetExamenUro(int id_examUG)
        {
            var examen = await _appDbContext.ExamenUroGenital.FirstOrDefaultAsync(x => x.id_examUG == id_examUG);
            if (examen == null)
                return NotFound();

            return Ok(examen);
        }


        [HttpPut("{id_examUG:int}")]
        public async Task<IActionResult> UpdateExamUro(int id_examUG, ExamenUroGenital updateExamen)
        {
            var existingExamen = await _appDbContext.ExamenUroGenital.FindAsync(id_examUG);
            if (existingExamen == null)
                return NotFound();

            // Update the existing entity with the values from the updated entity
            _appDbContext.Entry(existingExamen).CurrentValues.SetValues(updateExamen);

            // Save changes
            await _appDbContext.SaveChangesAsync();

            // Return the updated entity
            return Ok(existingExamen);
        }





        [HttpDelete("{id_examUG:int}")]
        public async Task<IActionResult> DeleteExamUro(int id_examUG)
        {
            var aspectGenerale = await _appDbContext.ExamenUroGenital.FindAsync(id_examUG);
            if (aspectGenerale == null)
                return NotFound("AspectGenerale not found");

            _appDbContext.Remove(aspectGenerale);
            await _appDbContext.SaveChangesAsync();

            return Ok("aspectGenerale deleted successfully");
        }


    }

}
