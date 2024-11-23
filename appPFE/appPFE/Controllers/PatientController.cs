using appPFE.data;
using appPFE.Dtos;
using appPFE.Modeles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/Patient")]
    public class PatientController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;


        public PatientController(AppDbContext appDbContext, IMapper mapper)
        {
            this._appDbContext = appDbContext;
            this._mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _appDbContext.Patients.ToListAsync();
            return Ok(patients);
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient( PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _appDbContext.Patients.AddAsync(patient);
            await _appDbContext.SaveChangesAsync();


            return Ok(patient);
        }
        [HttpGet("{Ipp}")]
        public async Task<IActionResult> GetPatient(int Ipp)
        {
            var patient = await _appDbContext.Patients.FirstOrDefaultAsync(x => x.Ipp == Ipp);
            if (patient == null)

                return NotFound();

            return Ok(patient);
        }
        [HttpPut("{Ipp}")]
        public async Task<IActionResult> Updatepatient([FromRoute] int Ipp, Patient patientData)
        {
            var patient = await _appDbContext.Patients.FindAsync(Ipp);
            if (patient == null)
                return NotFound();

            // Mettez à jour les propriétés de l'antécédent personnel avec les valeurs du DTO
            _appDbContext.Entry(patient).CurrentValues.SetValues(patientData);

            // Enregistrez les modifications dans la base de données
            await _appDbContext.SaveChangesAsync();

            // Retournez l'antécédent personnel mis à jour dans la réponse HTTP
            return Ok(patient);
        }

        [HttpDelete("{Ipp}")]
        public async Task<IActionResult> DeletePatient(int Ipp)
        {
            var patient = await _appDbContext.Patients.FindAsync(Ipp);
            if (patient == null)
                return NotFound();

            _appDbContext.Remove(patient);
            await _appDbContext.SaveChangesAsync();

            return Ok(patient);
        }
        [HttpDelete("AllPatients")]
        public IActionResult DeleteAllUsers(List<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
            {
                return BadRequest("No user IDs provided.");
            }

            try
            {
                var patientsToRemove = _appDbContext.Patients.Where(u => selectedIds.Contains(u.Ipp)).ToList();
                _appDbContext.Patients.RemoveRange(patientsToRemove);
                _appDbContext.SaveChanges();

                return Ok($"{patientsToRemove.Count} record(s) deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}

