using appPFE.data;
using appPFE.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/ExamOph")]
    public class ExamenOphController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ExamenOphController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEx()
        {
            var exam = await _appDbContext.ExamenOphtalmologique.ToListAsync();
            return Ok(exam);
        }

        [HttpPost("addExamOph/{Id_exam:int}")]
        public async Task<IActionResult> AddExamenOph(int Id_exam, [FromBody] ExamenOphtalmologique examenOph)
        {
            // Check if the patient with the given Ipp exists
            var exam = await _appDbContext.ExamenCliniques.FindAsync(Id_exam);
            if (exam == null)
            {
                return NotFound($"Exam with id_exam {Id_exam} not found.");
            }

            // Ensure the Ipp is assigned to the examenClinique
            examenOph.ophtId = Id_exam;

            try
            {
                _appDbContext.ExamenOphtalmologique.Add(examenOph);
                await _appDbContext.SaveChangesAsync();
                return Ok(examenOph);
            }
            catch (DbUpdateException ex)
            {
                // Log the error and return a bad request with the error details
                Console.WriteLine($"Error saving examen clinique: {ex.Message}");
                return BadRequest("An error occurred while saving the examen clinique. Please try again.");
            }
        }

        [HttpGet("{id_ExOph:int}")]
        public async Task<IActionResult> GetExamenOph(int id_ExOph)
        {
            var exam = await _appDbContext.ExamenOphtalmologique.FirstOrDefaultAsync(x => x.id_ExOph == id_ExOph);
            if (exam == null)
                return NotFound();

            return Ok(exam);
        }


        [HttpPut("{id_ExOph:int}")]
        public async Task<IActionResult> UpdateExamenOph(int id_ExOph, ExamenOphtalmologique updateEx)
        {
            var existingAspect = await _appDbContext.ExamenOphtalmologique.FindAsync(updateEx);
            if (existingAspect == null)
                return NotFound();

            // Update the existing entity with the values from the updated entity
            _appDbContext.Entry(existingAspect).CurrentValues.SetValues(updateEx);

            // Save changes
            await _appDbContext.SaveChangesAsync();

            // Return the updated entity
            return Ok(existingAspect);
        }





        [HttpDelete("{id_ExOph:int}")]
        public async Task<IActionResult> DeleteExamenOph(int id_ExOph)
        {
            var exam = await _appDbContext.ExamenOphtalmologique.FindAsync(id_ExOph);
            if (exam == null)
                return NotFound("AspectGenerale not found");

            _appDbContext.Remove(exam);
            await _appDbContext.SaveChangesAsync();

            return Ok("aspectGenerale deleted successfully");
        }


    }

}
