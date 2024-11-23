using appPFE.data;
using appPFE.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/aspectGeneral")]
    public class AspectGeneralController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public AspectGeneralController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAspects()
        {
            var aspectGeneral = await _appDbContext.AspectGenerale.ToListAsync();
            return Ok(aspectGeneral);
        }
     
        [HttpPost("addExamAsp/{Id_exam:int}")]
        public async Task<IActionResult> AddExamenAsp(int Id_exam, [FromBody] AspectGenerale aspectGenerale)
        {
            // Check if the patient with the given Ipp exists
            var patient = await _appDbContext.ExamenCliniques.FindAsync(Id_exam);
            if (patient == null)
            {
                return NotFound($"Exam with id_exam {Id_exam} not found.");
            }

            // Ensure the Ipp is assigned to the examenClinique
            aspectGenerale.examId = Id_exam; 

            try
            {
                _appDbContext.AspectGenerale.Add(aspectGenerale);
                await _appDbContext.SaveChangesAsync();
                return Ok(aspectGenerale);
            }
            catch (DbUpdateException ex)
            {
                // Log the error and return a bad request with the error details
                Console.WriteLine($"Error saving examen clinique: {ex.Message}");
                return BadRequest("An error occurred while saving the examen clinique. Please try again.");
            }
        }
      
        [HttpGet("{id_Aspect:int}")]
        public async Task<IActionResult> GetAspectGenerale(int id_Aspect)
        {
            var aspectGenerale = await _appDbContext.AspectGenerale.FirstOrDefaultAsync(x => x.id_Aspect == id_Aspect);
            if (aspectGenerale == null)
                return NotFound();

            return Ok(aspectGenerale);
        }


        [HttpPut("{id_Aspect:int}")]
        public async Task<IActionResult> UpdateAspectGenerale(int id_Aspect, AspectGenerale updateAspect)
        {
            var existingAspect = await _appDbContext.AspectGenerale.FindAsync(id_Aspect);
            if (existingAspect == null)
                return NotFound();

            // Update the existing entity with the values from the updated entity
            _appDbContext.Entry(existingAspect).CurrentValues.SetValues(updateAspect);

            // Save changes
            await _appDbContext.SaveChangesAsync();

            // Return the updated entity
            return Ok(existingAspect);
        }


       


        [HttpDelete("{id_Aspect:int}")]
        public async Task<IActionResult> DeleteAspectGenerale(int id_Aspect)
        {
            var aspectGenerale = await _appDbContext.AspectGenerale.FindAsync(id_Aspect);
            if (aspectGenerale == null)
                return NotFound("AspectGenerale not found");

            _appDbContext.Remove(aspectGenerale);
            await _appDbContext.SaveChangesAsync();

            return Ok("aspectGenerale deleted successfully");
        }


    }
}
