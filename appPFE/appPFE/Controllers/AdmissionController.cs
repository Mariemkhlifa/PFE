using appPFE.data;
using appPFE.Dtos;
using appPFE.Modeles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/admission")]
    public class AdmissionController : Controller
    {

        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;


        public AdmissionController(AppDbContext appDbContext, IMapper mapper)
        {
            this._appDbContext = appDbContext;
            this._mapper = mapper;

        }



        [HttpGet]
        public async Task<IActionResult> GetAllAdmissions()
        {
            var admissions = await _appDbContext.Admissions.ToListAsync();
            return Ok(admissions);
        }
       /* [HttpPost("addPatientAdmition/{Ipp:int}")]
        public async Task<IActionResult> AddAdmissionp(int Ipp, [FromBody] List<Admission> admissions)
        {
            var patient = await _appDbContext.Admissions.FindAsync(Ipp);
            if (patient == null)
            {
                return NotFound("Patient with Ipp {Ipp} not found.");
            }


            admission.AdmissionIpp = Ipp;

            _appDbContext.Admissions.Add(admission);
            await _appDbContext.SaveChangesAsync();
            return Ok(admission);


        }*/
        [HttpPost("addPatientAdmition/{Ipp:int}")]
        public async Task<IActionResult> AddExamen(int Ipp, [FromBody] List<Admission> admissions)
        {
            var patient = await _appDbContext.Patients.FindAsync(Ipp);
            if (patient == null)
            {
                return NotFound($"Patient with Ipp {Ipp} not found.");
            }

            if (admissions == null || !admissions.Any())
            {
                return BadRequest("No valid examination data provided.");
            }

            foreach (var admission in admissions)
            {
                admission.AdmissionIpp = Ipp;
                _appDbContext.Admissions.Add(admission);
            }

            await _appDbContext.SaveChangesAsync();
            return Ok(admissions);
        }


        [HttpGet("{id_adm}")]
       
        public async Task<IActionResult> GetAdmission(int id_adm)
        {
            var admission = await _appDbContext.Admissions.FirstOrDefaultAsync(x => x.id_adm == id_adm);
            if (admission == null)
                return NotFound();

            return Ok(admission);
        }
      

        [HttpPut("update/{id_adm:int}")]
        public async Task<IActionResult> UpdateAdmission([FromRoute] int id_adm, AdmissionDto updateAdmission)
        {
            var admission = await _appDbContext.Admissions.FindAsync(id_adm);
            if (admission == null)
                return NotFound();

            _appDbContext.Entry(admission).CurrentValues.SetValues(updateAdmission);

            await _appDbContext.SaveChangesAsync();

            return Ok(admission);
        }
     


        [HttpDelete("{id_adm:int}")]
        public async Task<IActionResult> DeleteAdmission(int id_adm)
        {
            var admission = await _appDbContext.Admissions.FindAsync(id_adm);
            if (admission == null)
                return NotFound();

            _appDbContext.Remove(admission);
            await _appDbContext.SaveChangesAsync();

            return Ok(admission);
        }
       

    }
}
