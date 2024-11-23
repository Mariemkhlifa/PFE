using appPFE.data;
using appPFE.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/ExamNeuro")]
    public class ExamenNeuroController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ExamenNeuroController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExamenNeuro()
        {
            var examenNeuro = await _appDbContext.ExamenNeurologique.ToListAsync();
            return Ok(examenNeuro);
        }

        [HttpPost("addExNeuro/{Id_exam:int}")]
        public async Task<IActionResult> AddExamenNeuro(int Id_exam, [FromBody] ExamenNeurologique examenNeuro)
        {
            // Check if the patient with the given Ipp exists
            var examen = await _appDbContext.ExamenCliniques.FindAsync(Id_exam);
            if (examen == null)
            {
                return NotFound($"Exam with id_exam {Id_exam} not found.");
            }

            // Ensure the Ipp is assigned to the examenClinique
            examenNeuro.NeuroId = Id_exam;

            try
            {
                _appDbContext.ExamenNeurologique.Add(examenNeuro);
                await _appDbContext.SaveChangesAsync();
                return Ok(examenNeuro);
            }
            catch (DbUpdateException ex)
            {
                // Log the error and return a bad request with the error details
                Console.WriteLine($"Error saving examen clinique: {ex.Message}");
                return BadRequest("An error occurred while saving the examen clinique. Please try again.");
            }
        }

        [HttpGet("{id_ExN:int}")]
        public async Task<IActionResult> GetExamenNeuro(int id_ExN)
        {
            var examenNeuro = await _appDbContext.ExamenNeurologique.FirstOrDefaultAsync(x => x.id_ExN == id_ExN);
            if (examenNeuro == null)
                return NotFound();

            return Ok(examenNeuro);
        }


        [HttpPut("{id_ExN:int}")]
        public async Task<IActionResult> UpdateExamenNeuro(int id_ExN, ExamenNeurologique updateEx)
        {
            var existingEx = await _appDbContext.ExamenNeurologique.FindAsync(id_ExN);
            if (existingEx == null)
                return NotFound();

            // Update the existing entity with the values from the updated entity
            _appDbContext.Entry(existingEx).CurrentValues.SetValues(updateEx);

            // Save changes
            await _appDbContext.SaveChangesAsync();

            // Return the updated entity
            return Ok(existingEx);
        }





        [HttpDelete("{id_ExNeuro:int}")]
        public async Task<IActionResult> DeleteExamenNeuro(int id_ExNeuro)
        {
            var examenCardHemo = await _appDbContext.ExamenNeurologique.FindAsync(id_ExNeuro);
            if (examenCardHemo == null)
                return NotFound("ExamenNeuro not found");

            _appDbContext.Remove(examenCardHemo);
            await _appDbContext.SaveChangesAsync();

            return Ok("ExamenNeuro deleted successfully");
        }
    }
}
