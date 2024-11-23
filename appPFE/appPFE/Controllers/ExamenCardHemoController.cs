using appPFE.data;
using appPFE.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/examenCardHemo")]
    public class ExamenCardHemoController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ExamenCardHemoController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExamenCardHemo()
        {
            var examenCardHemo = await _appDbContext.ExamenCardHemo.ToListAsync();
            return Ok(examenCardHemo);
        }
      
        [HttpPost("addExCardHemo/{Id_exam:int}")]
        public async Task<IActionResult> AddExamenCardHemo(int Id_exam, [FromBody] ExamenCardHemo examenCardHemo)
        {
            // Check if the patient with the given Ipp exists
            var examen = await _appDbContext.ExamenCliniques.FindAsync(Id_exam);
            if (examen == null)
            {
                return NotFound($"Exam with id_exam {Id_exam} not found.");
            }

            // Ensure the Ipp is assigned to the examenClinique
            examenCardHemo.examId = Id_exam;

            try
            {
                _appDbContext.ExamenCardHemo.Add(examenCardHemo);
                await _appDbContext.SaveChangesAsync();
                return Ok(examenCardHemo);
            }
            catch (DbUpdateException ex)
            {
                // Log the error and return a bad request with the error details
                Console.WriteLine($"Error saving examen clinique: {ex.Message}");
                return BadRequest("An error occurred while saving the examen clinique. Please try again.");
            }
        }

        [HttpGet("{id_ExCardHEmo:int}")]
        public async Task<IActionResult> GetExamenCardHemo(int id_ExCardHEmo)
        {
            var examenCardHemo = await _appDbContext.ExamenCardHemo.FirstOrDefaultAsync(x => x.id_ExCardHEmo == id_ExCardHEmo);
            if (examenCardHemo == null)
                return NotFound();

            return Ok(examenCardHemo);
        }


        [HttpPut("{id_ExCardHEmo:int}")]
        public async Task<IActionResult> UpdateExamenCardHemo(int id_ExCardHEmo, ExamenCardHemo updateEx)
        {
            var existingEx = await _appDbContext.ExamenCardHemo.FindAsync(id_ExCardHEmo);
            if (existingEx == null)
                return NotFound();

            // Update the existing entity with the values from the updated entity
            _appDbContext.Entry(existingEx).CurrentValues.SetValues(updateEx);

            // Save changes
            await _appDbContext.SaveChangesAsync();

            // Return the updated entity
            return Ok(existingEx);
        }





        [HttpDelete("{id_ExCardHEmo:int}")]
        public async Task<IActionResult> DeleteExamenCardHemo(int id_ExCardHEmo)
        {
            var examenCardHemo = await _appDbContext.ExamenCardHemo.FindAsync(id_ExCardHEmo);
            if (examenCardHemo == null)
                return NotFound("ExamenCardHemo not found");

            _appDbContext.Remove(examenCardHemo);
            await _appDbContext.SaveChangesAsync();

            return Ok("ExamenCardHemo deleted successfully");
        }


    
}
}
