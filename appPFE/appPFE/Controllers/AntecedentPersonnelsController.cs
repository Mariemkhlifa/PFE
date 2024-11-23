using appPFE.data;
using appPFE.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/antecedentP")]
    public class AntecedentPersonnelsController : Controller
    {
    
            private readonly AppDbContext _appDbContext;
            public AntecedentPersonnelsController(AppDbContext appDbContext)
            {
                this._appDbContext = appDbContext;
            }
            [HttpGet]
            [Route("GetAllAntecedentsP")]

            public async Task<IActionResult> GetAllAntecedents()
            {
                var antecedentsP = await _appDbContext.AntecedentPersonnels.ToListAsync();
                return Ok(antecedentsP);
            }
            [HttpPost]
            [Route("AddAntecedentP")]
            public async Task<IActionResult> AddAntecedentP([FromBody] AntecedentPersonnels antecedentPersonnels)
            {
                _appDbContext.AntecedentPersonnels.Add(antecedentPersonnels);
                await _appDbContext.SaveChangesAsync();

                return Ok(antecedentPersonnels);
            }
            [HttpGet]
            [Route("GetAntecedentPBy/{Id_AntecP:int}")]
            public async Task<IActionResult> GetAntecedentP(int Id_AntecP)
            {
                var antecedentPersonnels = await _appDbContext.AntecedentPersonnels.FirstOrDefaultAsync(x => x.Id_AntecP == Id_AntecP);
                if (antecedentPersonnels == null)
                    return NotFound();

                return Ok(antecedentPersonnels);
            }




            [HttpPut]
            [Route("UpdateAntecedentP/{Id_AntecP:int}")]
            public async Task<IActionResult> UpdateAntecedentP(int Id_AntecP, AntecedentPersonnels updateAntecedentRequest)
            {
                var antecedentPersonnels = await _appDbContext.AntecedentFamiliaux.FindAsync(Id_AntecP);
                if (antecedentPersonnels == null)
                    return NotFound();

                // Mettez à jour les propriétés de l'antécédent personnel avec les valeurs du DTO
                _appDbContext.Entry(antecedentPersonnels).CurrentValues.SetValues(updateAntecedentRequest);

                // Enregistrez les modifications dans la base de données
                await _appDbContext.SaveChangesAsync();

                // Retournez l'antécédent personnel mis à jour dans la réponse HTTP
                return Ok(antecedentPersonnels);
            }

            [HttpDelete]
            [Route("DeleteAntecedentP/{Id_AntecP:int}")]
            public async Task<IActionResult> DeleteAntecedentF(int Id_AntecP)
            {
                var antecedentPersonnels = await _appDbContext.AntecedentFamiliaux.FindAsync(Id_AntecP);
                if (antecedentPersonnels == null)
                    return NotFound();

                _appDbContext.Remove(antecedentPersonnels);
                await _appDbContext.SaveChangesAsync();

                return Ok(antecedentPersonnels);
            }

        }
    
}
