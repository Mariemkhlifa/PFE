using appPFE.data;
using appPFE.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/accouchement")]
    public class AccouchementController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public AccouchementController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAccouchements()
        {
            var accouchement = await _appDbContext.Accouchements.ToListAsync();
            return Ok(accouchement);
        }
        [HttpPost]
        public async Task<IActionResult> AddAccouchement([FromBody] Accouchement accouchement)
        {
            _appDbContext.Accouchements.Add(accouchement);
            await _appDbContext.SaveChangesAsync();

            return Ok(accouchement);
        }
        [HttpGet("{Num_Acc:int}")]
        public async Task<IActionResult> GetAccouchement(int Num_Acc)
        {
            var accouchement = await _appDbContext.Accouchements.FirstOrDefaultAsync(x => x.Num_Acc == Num_Acc);
            if (accouchement == null)
                return NotFound();

            return Ok(accouchement);
        }

        [HttpPut("{Num_Acc:int}")]
        public async Task<IActionResult> UpdatetAccouchement(int Num_Acc, Accouchement updateAccouchement)
        {
            var existingAccouchement = await _appDbContext.Accouchements.FindAsync(Num_Acc);
            if (existingAccouchement == null)
                return NotFound();

            // Update the existing entity with the values from the updated entity
            _appDbContext.Entry(existingAccouchement).CurrentValues.SetValues(updateAccouchement);

            // Save changes
            await _appDbContext.SaveChangesAsync();

            // Return the updated entity
            return Ok(existingAccouchement);
        }


       

        [HttpDelete("{Num_Acc:int}")]
        public async Task<IActionResult> DeleteAccouchement(int Num_Acc)
        {
            var accouchement = await _appDbContext.Accouchements.FindAsync(Num_Acc);
            if (accouchement == null)
                return NotFound("Accouchement not found");

            _appDbContext.Remove(accouchement);
            await _appDbContext.SaveChangesAsync();

            return Ok("Accouchement deleted successfully");
        }


    }


}
