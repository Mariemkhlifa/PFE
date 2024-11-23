using appPFE.data;
using appPFE.Dtos;
using appPFE.Modeles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/antecedentF")]
    public class AntecedentsFamiliauxController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AntecedentsFamiliauxController(AppDbContext appDbContext, IMapper mapper)
        {
            this._appDbContext = appDbContext;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAntecedents()
        {
            var antecedentsF = await _appDbContext.AntecedentFamiliaux.ToListAsync();
            return Ok(antecedentsF);
        }
      

        [HttpPost("addAntecedentPatient/{Ipp:int}")]
        public async Task<IActionResult> AddAntecedent(int Ipp, [FromBody] AntecedentsFamiliaux antecedentFamiliaux)
        {
            var patient = await _appDbContext.Patients.FindAsync(Ipp);
            if (patient == null)
            {
                return NotFound("Patient with Ipp {Ipp} not found.");
            }

            antecedentFamiliaux.PatientIpp = Ipp; 

           
          
                _appDbContext.AntecedentFamiliaux.Add(antecedentFamiliaux);
                await _appDbContext.SaveChangesAsync();
                return Ok(antecedentFamiliaux);
            
          
        }
        [HttpGet("{Id_AntecF:int}")]
        public async Task<IActionResult> GetAntecedentF(int Id_AntecF)
        {
            var antecedentFamiliaux = await _appDbContext.AntecedentFamiliaux.FirstOrDefaultAsync(x => x.Id_AntecF == Id_AntecF);
            if (antecedentFamiliaux == null)
                return NotFound();

            return Ok(antecedentFamiliaux);
        }




        [HttpPut("{Id_AntecF:int}")]
        public async Task<IActionResult> UpdateAntecedentF(int Id_AntecF, AntecedentsFamiliaux updateAntecedentRequest)
        {
            var antecedentFamiliaux = await _appDbContext.AntecedentFamiliaux.FindAsync(Id_AntecF);
            if (antecedentFamiliaux == null)
                return NotFound();

            // Mettez à jour les propriétés de l'antécédent personnel avec les valeurs du DTO
            _appDbContext.Entry(antecedentFamiliaux).CurrentValues.SetValues(updateAntecedentRequest);

            // Enregistrez les modifications dans la base de données
            await _appDbContext.SaveChangesAsync();

            // Retournez l'antécédent personnel mis à jour dans la réponse HTTP
            return Ok(antecedentFamiliaux);
        }

        [HttpDelete("{Id_AntecF:int}")]
        public async Task<IActionResult> DeleteAntecedentF(int Id_AntecF)
        {
            var antecedentFamiliaux = await _appDbContext.AntecedentFamiliaux.FindAsync(Id_AntecF);
            if (antecedentFamiliaux == null)
                return NotFound();

            _appDbContext.Remove(antecedentFamiliaux);
            await _appDbContext.SaveChangesAsync();

            return Ok(antecedentFamiliaux);
        }

    }
}
