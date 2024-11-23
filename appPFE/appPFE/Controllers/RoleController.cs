using appPFE.data;
using appPFE.Dtos;
using appPFE.Modeles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/Role")]
    public class RoleController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public RoleController(AppDbContext appDbContext, IMapper mapper)
        {
            this._appDbContext = appDbContext;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> AfficheTousRoles()
        {
            var users = await _appDbContext.Roles.ToListAsync();
            return Ok(users);
        }
        [HttpGet("AllUserRole")]
        public async Task<IActionResult> AllUserRole()
        {
            var users = await _appDbContext.UserRoles.ToListAsync();
            return Ok(users);
        }


        [HttpPost]
        public async Task<IActionResult> AjouterRole([FromBody] RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            _appDbContext.Roles.Add(role);
            await _appDbContext.SaveChangesAsync();


            return Ok(role);
        }

        [HttpGet("{IdRole}")]
        public async Task<IActionResult> AfficherRole(int IdRole)
        {
            var role = await _appDbContext.Roles.FirstOrDefaultAsync(x => x.Role_id == IdRole);

            if (role == null)
            {
                return NotFound(); 
            }

            return Ok(role); 
        }
        [HttpPut("{IdRole:int}")]
        public async Task<IActionResult> UpdatetAccouchement(int IdRole, RoleDto roleDto)
        {
            var roleMap = _mapper.Map<Role>(roleDto);
            var role = await _appDbContext.Roles.FindAsync(IdRole);
            if (role == null)
                return NotFound();

            // Update the existing entity with the values from the updated entity
            _appDbContext.Entry(role).CurrentValues.SetValues(roleDto);

            // Save changes
            await _appDbContext.SaveChangesAsync();

            // Return the updated entity
            return Ok(role);
        }
       
        [HttpDelete("{IdRole}")]
        public async Task<IActionResult> SupprimerRole(int IdRole)
        {
            var role = await _appDbContext.Roles.FindAsync(IdRole);
            if (role == null)
                return NotFound();

            _appDbContext.Remove(role);
            await _appDbContext.SaveChangesAsync();

            return Ok(role);
        }
       


    }

}
    

