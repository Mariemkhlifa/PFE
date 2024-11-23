namespace appPFE.Controllers
{
    using AutoMapper;
    using global::appPFE.data;
    using global::appPFE.Dtos;
    using global::appPFE.Modeles;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using static System.Runtime.InteropServices.JavaScript.JSType;
    using Microsoft.AspNetCore.Authorization;
    using System.Net;
    using System.Net.Mail;
    using Microsoft.AspNetCore.Identity;
 

    //using System.Web.Http;


    namespace appPFE.Controllers
    {
        [ApiController]
        [Route("api/user")] // Remove the leading slash
        public class UserController : Controller
        {
            private readonly AppDbContext _appDbContext;
            private readonly IMapper _mapper;
           
            public UserController(AppDbContext appDbContext, IMapper mapper)
            {
                this._appDbContext = appDbContext;
                this._mapper = mapper;
              
            }

            [HttpGet]
           
            public async Task<IActionResult> GetAllUsers()
            {
                var users = await _appDbContext.Users.ToListAsync();
                return Ok(users);
            }

            [HttpPost]
            public async Task<IActionResult> AddUser(UserDto userDto)
            {
                var user = _mapper.Map<User>(userDto);
                user.password = HashPassword(user.password);
                user.statut = true; // Default status to true

                _appDbContext.Users.Add(user);
                await _appDbContext.SaveChangesAsync();

                return Ok(user);
            }

            [HttpGet("{Id_User}")]
            public async Task<IActionResult> GetUser(int Id_User)
            {
                var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.User_id == Id_User);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }

            [HttpPut("{Num_Aspect:int}")]
            public async Task<IActionResult> UpdateAspectGenerale(int Num_Aspect, AspectGenerale updateAspect)
            {
                var existingAspect = await _appDbContext.AspectGenerale.FindAsync(Num_Aspect);
                if (existingAspect == null)
                    return NotFound();

                _appDbContext.Entry(existingAspect).CurrentValues.SetValues(updateAspect);
                await _appDbContext.SaveChangesAsync();

                return Ok(existingAspect);
            }




            [HttpPut("update/{UserId}")]
            public async Task<IActionResult> Updatepatient([FromRoute] int UserId, User userData)
            {
                var patient = await _appDbContext.Users.FindAsync(UserId);
                if (patient == null)
                    return NotFound();

                // Mettez à jour les propriétés de l'antécédent personnel avec les valeurs du DTO
                _appDbContext.Entry(patient).CurrentValues.SetValues(userData);

                // Enregistrez les modifications dans la base de données
                await _appDbContext.SaveChangesAsync();

                // Retournez l'antécédent personnel mis à jour dans la réponse HTTP
                return Ok(patient);
            }


            private string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }

            [HttpDelete("{IdUser}")]
            public async Task<IActionResult> DeleteUser(int IdUser)
            {
                var user = await _appDbContext.Users.FindAsync(IdUser);
                if (user == null)
                    return NotFound();

                _appDbContext.Users.Remove(user);
                await _appDbContext.SaveChangesAsync();

                return Ok(user);
            }

            [HttpDelete("AllUsers")]
            public IActionResult deleteAllUsers(List<int> selectedIds)
            {
                if (selectedIds == null || !selectedIds.Any())
                    return BadRequest("No user IDs provided.");

                var clientsToRemove = _appDbContext.Users.Where(u => selectedIds.Contains(u.User_id)).ToList();
                _appDbContext.Users.RemoveRange(clientsToRemove);
                _appDbContext.SaveChanges();

                return Ok($"{clientsToRemove.Count} record(s) deleted successfully.");
            }

            /*[HttpPost("AddUserRole")]
            public async Task<IActionResult> AddUserRole(int userId, int roleId)
            {
                // Recherche de l'utilisateur par userId
                var user = await _appDbContext.Users.FindAsync(userId);
                if (user == null)
                    return NotFound("Utilisateur non trouvé");

                // Recherche du rôle par roleId
                var role = await _appDbContext.Roles.FindAsync(roleId);
                if (role == null)
                    return NotFound("Rôle non trouvé");

                // Vérification si l'utilisateur possède déjà ce rôle
                var existingUserRole = await _appDbContext.UserRoles
                    .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
                if (existingUserRole != null)
                    return BadRequest("L'utilisateur possède déjà ce rôle");

                // Ajout du rôle à l'utilisateur
                _appDbContext.UserRoles.Add(new UserRole { UserId = userId, RoleId = roleId });
                await _appDbContext.SaveChangesAsync();

                return Ok("Rôle ajouté avec succès à l'utilisateur");
            }*/
            [HttpPost("AddUserRole")]
            public async Task<IActionResult> AddUserRole([FromBody] UserRoleDto userRole)
            {
                var user = await _appDbContext.Users.FindAsync(userRole.userId);
                if (user == null)
                    return NotFound("Utilisateur non trouvé");

                var role = await _appDbContext.Roles.FindAsync(userRole.roleId);
                if (role == null)
                    return NotFound("Rôle non trouvé");

                var existingUserRole = await _appDbContext.UserRoles
                    .FirstOrDefaultAsync(ur => ur.userId == userRole.userId && ur.roleId == userRole.roleId);
                if (existingUserRole != null)
                    return BadRequest("L'utilisateur possède déjà ce rôle");

                _appDbContext.UserRoles.Add(new UserRole { userId = userRole.userId, roleId = userRole.roleId });
                await _appDbContext.SaveChangesAsync();

                return Ok("Rôle ajouté avec succès à l'utilisateur");
            }

           

            [HttpPut("statut/{userId}")]
            public async Task<IActionResult> UpdateUserStatus(int userId, [FromBody] User request)
            {
                var user = await _appDbContext.Users.FindAsync(userId);
                if (user == null)
                    return NotFound("Utilisateur non trouvé");

                if (user.statut != request.statut)
                {
                    user.statut = request.statut;

                    try
                    {
                        _appDbContext.Users.Update(user);
                        await _appDbContext.SaveChangesAsync();
                        return Ok(request.statut
                            ? $"Statut de l'utilisateur {user.User_id} activé avec succès."
                            : $"Statut de l'utilisateur {user.User_id} désactivé avec succès.");
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, $"Une erreur s'est produite lors de la mise à jour du statut de l'utilisateur : {ex.Message}");
                    }
                }

                return BadRequest($"Le statut de l'utilisateur {user.User_id} est déjà défini sur {(request.statut ? "actif" : "inactif")}.");
            }





        }

        
    }



        


    }





