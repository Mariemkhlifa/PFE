
using appPFE.data;
using appPFE.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/Evolution")]
    public class EvolutionController : Controller
    {

            private readonly AppDbContext _appDbContext;


        public EvolutionController(AppDbContext appDbContext)
            {
                this._appDbContext = appDbContext;

            }
            [HttpGet]
           

            public async Task<IActionResult> GetAllEvolution()
            {
                var evolution = await _appDbContext.Evolutions.ToListAsync();
                return Ok(evolution);
            }
         

        [HttpPost("AddEVAdmission/{Id_adm:int}")]
        public async Task<IActionResult> AddEvolution(int Id_adm, [FromBody] Evolution evolution)
        {
            // Check if the patient with the given Ipp exists
            var examen = await _appDbContext.Admissions.FindAsync(Id_adm);
            if (examen == null)
            {
                return NotFound($"Admission with Id_adm {Id_adm} not found.");
            }

            // Ensure the Ipp is assigned to the examenClinique
            evolution.AdmissionId = Id_adm;

            try
            {
                _appDbContext.Evolutions.Add(evolution);
                await _appDbContext.SaveChangesAsync();
                return Ok(evolution);
            }
            catch (DbUpdateException ex)
            {
                // Log the error and return a bad request with the error details
                Console.WriteLine($"Error saving examen clinique: {ex.Message}");
                return BadRequest("An error occurred while saving the examen clinique. Please try again.");
            }
        }

        [HttpGet("{Num_Ev:int}")]
            public async Task<IActionResult> GetEvolution(int Num_Ev)
            {
                var evolution = await _appDbContext.Evolutions.FirstOrDefaultAsync(x => x.Num_Ev == Num_Ev);
                if (evolution == null)
                    return NotFound();

                return Ok(evolution);
            }



        [HttpPut("{Num_Ev:int}")]
        public async Task<IActionResult> UpdateEvolution(int Num_Ev, Evolution updateEvolutionRequest)
        {
            var evolution = await _appDbContext.Evolutions.FindAsync(Num_Ev);
            if (evolution == null)
                return NotFound();

            // Preserve the original AdmissionId
            updateEvolutionRequest.AdmissionId = evolution.AdmissionId;

            _appDbContext.Entry(evolution).CurrentValues.SetValues(updateEvolutionRequest);

            try
            {
                await _appDbContext.SaveChangesAsync();
                return Ok(evolution);
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547) // SQL Server foreign key violation
            {
                return BadRequest("Invalid AdmissionId. Please ensure the AdmissionId exists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving evolution: {ex.Message}");
                return StatusCode(500, "An error occurred while saving the evolution. Please try again.");
            }
        }


        [HttpDelete("{Num_Ev:int}")]
            public async Task<IActionResult> DeleteEvolution(int Num_Ev)
            {
                var evolution = await _appDbContext.Evolutions.FindAsync(Num_Ev);
                if (evolution == null)
                    return NotFound();

                _appDbContext.Remove(evolution);
                await _appDbContext.SaveChangesAsync();

                return Ok(evolution);
            }

        }
    
}
