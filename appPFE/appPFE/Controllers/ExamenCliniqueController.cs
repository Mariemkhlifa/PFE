using appPFE.data;
using appPFE.Dtos;
using appPFE.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/examen")]
    public class ExamenCliniqueController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ExamenCliniqueController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExamens()
        {
            var examens = await _appDbContext.ExamenCliniques
                .Include(e => e.Patient)
                .Include(e => e.ExamenRespiratoire)
                .Include(e => e.ExamenOrthopedique)
                .Include(e => e.ExamenUroGenital)
                .Include(e => e.ExamenSomatique)
                .Include(e => e.ExamenOphtalmologique)
                .Include(e => e.ExamenNeurologique)
                .Include(e => e.ExamenCutanePhaneres)
                .Include(e => e.AspectGenerale)
                .Include(e => e.ExamenCardHemo)
                .Include(e => e.ExamenAbdominal)
                .ToListAsync();

            return Ok(examens);
        }

 
        [HttpPost("addExamenPatient/{Ipp:int}")]
        public async Task<IActionResult> AddExamen(int Ipp, [FromBody] List<ExamenClinique> examenCliniques)
        {
            var patient = await _appDbContext.Patients.FindAsync(Ipp);
            if (patient == null)
            {
                return NotFound($"Patient with Ipp {Ipp} not found.");
            }

            if (examenCliniques == null || !examenCliniques.Any())
            {
                return BadRequest("No valid examination data provided.");
            }

            foreach (var examenClinique in examenCliniques)
            {
                examenClinique.PatientIpp = Ipp;
                _appDbContext.ExamenCliniques.Add(examenClinique);
            }

            await _appDbContext.SaveChangesAsync();
            return Ok(examenCliniques);
        }



        /*[HttpPost("addAntecedentPatient/{Ipp:int}")]
        public async Task<IActionResult> AddAntecedentF(int Ipp, AntecedentFamiliauxDto antecedentFamiliauxDto)
        {
            var antecedentFamiliaux = await _appDbContext.AntecedentFamiliaux.FindAsync(Ipp);

            antecedentFamiliaux = _mapper.Map<AntecedentsFamiliaux>(antecedentFamiliauxDto);

            _appDbContext.AntecedentFamiliaux.Add(antecedentFamiliaux);
            await _appDbContext.SaveChangesAsync();

            return Ok(antecedentFamiliaux);
        }*/
        [HttpGet("{id_exam:int}")]
        public async Task<IActionResult> GetExamen(int id_exam)
        {
           // var examenClinique = await _appDbContext.ExamenClinique.FirstOrDefaultAsync(x => x.id_exam == id_exam);
            var examenClinique = await _appDbContext.ExamenCliniques
             .Include(e => e.Patient)
             .Include(e => e.ExamenRespiratoire)
             .Include(e => e.ExamenOrthopedique)
             .Include(e => e.ExamenUroGenital)
             .Include(e => e.ExamenSomatique)
             .Include(e => e.ExamenOphtalmologique)
             .Include(e => e.ExamenNeurologique)
             .Include(e => e.ExamenCutanePhaneres)
             .Include(e => e.AspectGenerale)
             .Include(e => e.ExamenCardHemo)
             .Include(e => e.ExamenAbdominal)
             .FirstOrDefaultAsync(x => x.id_exam == id_exam);
            if (examenClinique == null)

                return NotFound();

            return Ok(examenClinique);
        }
      
        [HttpPut("{id_exam:int}")]
        public async Task<IActionResult> UpdateExamen([FromRoute] int id_exam,  ExamenClinique examenDto)
        {
            var examen = await _appDbContext.ExamenCliniques.FindAsync(id_exam);
            if (examen == null)
                return NotFound();

            // Mettez à jour les propriétés de l'antécédent personnel avec les valeurs du DTO
            _appDbContext.Entry(examen).CurrentValues.SetValues(examenDto);

            // Enregistrez les modifications dans la base de données
            await _appDbContext.SaveChangesAsync();

            return Ok(examen);
        }

        [HttpDelete("{id_exam:int}")]
        public async Task<IActionResult> DeleteExamen(int id_exam)
        {
            var examenClinique = await _appDbContext.ExamenCliniques.FindAsync(id_exam);
            if (examenClinique == null)
                return NotFound();

            _appDbContext.Remove(examenClinique);
            await _appDbContext.SaveChangesAsync();

            return Ok(examenClinique);
        }
    }

    }

