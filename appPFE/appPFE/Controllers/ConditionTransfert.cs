using appPFE.data;
using appPFE.Dtos;
using appPFE.Modeles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/ConditionTransfert")]
    public class ConditionTransfert : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;


        public ConditionTransfert(AppDbContext appDbContext, IMapper mapper)
        {
            this._appDbContext = appDbContext;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllConditionsTransfert()
        {
            var conditionsTransfert = await _appDbContext.ConditionsTransfert.ToListAsync();
            return Ok(conditionsTransfert);
        }

        /*[HttpPost]
        public async Task<IActionResult> AddConditionsTransfert(ConditionsTransfert conditionsTransfert)
        {
            await _appDbContext.ConditionsTransfert.AddAsync(conditionsTransfert);
            await _appDbContext.SaveChangesAsync();


            return Ok(conditionsTransfert);
        }*/
        [HttpPost("{Id_adm:int}")]
        public async Task<IActionResult> AddExamenCardHemo(int Id_adm, [FromBody] ConditionsTransfert conditionsTransfert)
        {
            // Check if the patient with the given Ipp exists
            var examen = await _appDbContext.Admissions.FindAsync(Id_adm);
            if (examen == null)
            {
                return NotFound($"Admission with Id_adm {Id_adm} not found.");
            }

            // Ensure the Ipp is assigned to the examenClinique
            conditionsTransfert.CtAdm = Id_adm;

            try
            {
                _appDbContext.ConditionsTransfert.Add(conditionsTransfert);
                await _appDbContext.SaveChangesAsync();
                return Ok(conditionsTransfert);
            }
            catch (DbUpdateException ex)
            {
                // Log the error and return a bad request with the error details
                Console.WriteLine($"Error saving examen clinique: {ex.Message}");
                return BadRequest("An error occurred while saving the examen clinique. Please try again.");
            }
        }
        [HttpGet("{Num_Condition}")]
        public async Task<IActionResult> GetConditionsTransfert(int Num_Condition)
        {
            var conditionsTransfert = await _appDbContext.ConditionsTransfert.FirstOrDefaultAsync(x => x.Num_Condition == Num_Condition);
            if (conditionsTransfert == null)

                return NotFound();

            return Ok(conditionsTransfert);
        }
        [HttpPut("{Num_Condition}")]
        public async Task<IActionResult> UpdateConditionsTransfert([FromRoute] int Num_Condition, ConditionsTransfert UpdateConditions)
        {
            var existingCondition = await _appDbContext.ConditionsTransfert.FindAsync(Num_Condition);
            if (existingCondition == null)
                return NotFound();

            // Validate the CtAdm value
            var admissionExists = await _appDbContext.Admissions.AnyAsync(a => a.id_adm == UpdateConditions.CtAdm);
            if (!admissionExists)
                return BadRequest("Invalid CtAdm. Ensure that it corresponds to an existing admission.");

            UpdateConditions.CtAdm = existingCondition.CtAdm;

            _appDbContext.Entry(existingCondition).CurrentValues.SetValues(UpdateConditions);

            try
            {
                await _appDbContext.SaveChangesAsync();
                return Ok(existingCondition);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                {
                    return BadRequest("Foreign key constraint violation. Ensure that CtAdm corresponds to an existing admission.");
                }

                return StatusCode(500, "An error occurred while updating the conditions transfert. Please try again.");
            }
        }


        [HttpDelete("{Num_Condition}")]
        public async Task<IActionResult> DeleteConditionsTransfert(int Num_Condition)
        {
            var conditionsTransfert = await _appDbContext.ConditionsTransfert.FindAsync(Num_Condition);
            if (conditionsTransfert == null)
                return NotFound();

            _appDbContext.Remove(conditionsTransfert);
            await _appDbContext.SaveChangesAsync();

            return Ok(conditionsTransfert);
        }
        /*[HttpDelete("AllPatients")]
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
        }*/

    }


}
