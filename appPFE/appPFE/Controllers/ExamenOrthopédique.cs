using appPFE.data;
using appPFE.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/examenOrtho")]
    public class ExamenOrthopédique : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ExamenOrthopédique(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExamenOrtho()
        {
            var aspectGeneral = await _appDbContext.ExamenOrthopedique.ToListAsync();
            return Ok(aspectGeneral);
        }

     
        

        [HttpGet("{id_examOrth:int}")]
        public async Task<IActionResult> GetExamenOrtho(int id_examOrth)
        {
            var examen = await _appDbContext.ExamenOrthopedique.FirstOrDefaultAsync(x => x.id_examOrth == id_examOrth);
            if (examen == null)
                return NotFound();

            return Ok(examen);
        }


        [HttpPut("{id_examOrth:int}")]
        public async Task<IActionResult> UpdateExamenOrtho(int id_examOrth, ExamenUroGenital updateExamen)
        {
            var existingExamen = await _appDbContext.ExamenOrthopedique.FindAsync(id_examOrth);
            if (existingExamen == null)
                return NotFound();

            // Update the existing entity with the values from the updated entity
            _appDbContext.Entry(existingExamen).CurrentValues.SetValues(updateExamen);

            // Save changes
            await _appDbContext.SaveChangesAsync();

            // Return the updated entity
            return Ok(existingExamen);
        }





        [HttpDelete("{id_examOrth:int}")]
        public async Task<IActionResult> DeleteExamenOrtho(int id_examOrth)
        {
            var exOrth = await _appDbContext.ExamenOrthopedique.FindAsync(id_examOrth);
            if (exOrth == null)
                return NotFound("AspectGenerale not found");

            _appDbContext.Remove(exOrth);
            await _appDbContext.SaveChangesAsync();

            return Ok("aspectGenerale deleted successfully");
        }


    }
}

