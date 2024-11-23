using appPFE.data;
using appPFE.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.AspNet.Identity;
using appPFE.Dtos;
using AutoMapper;
using System.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System;

namespace appPFE.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : Controller

    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;


        public AuthController(AppDbContext appDbContext, IMapper mapper)
        {
            this._appDbContext = appDbContext;
            this._mapper = mapper;

        }
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid client request");
            }

            // Verify user credentials
            var authenticatedUser = CheckUser(userDto.username, userDto.password);
            if (!string.IsNullOrEmpty(authenticatedUser))
            {
                // Retrieve user from the database to check account status
                var userFromDb = await _appDbContext.Users
                                                    .Include(u => u.UserRoles)
                                                        .ThenInclude(ur => ur.Role)
                                                    .FirstOrDefaultAsync(u => u.username == userDto.username);

                if (userFromDb != null && !userFromDb.statut)
                {
                    // Account deactivated, return failure message
                    return Unauthorized("Your account has been deactivated. Please contact the administrator.");
                }

                // Generate the JWT token
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super secret key with a length of at least 256 bits"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, authenticatedUser),
            new Claim(ClaimTypes.Name, userFromDb.nom_user)
        };

                // Add roles to the claims
                foreach (var userRole in userFromDb.UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole.Role.nomRole));
                }

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:24543",
                    audience: "http://localhost:24543",
                    claims: claims,
                    expires: DateTime.Now.AddHours(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                // Add the token to the response header
                HttpContext.Response.Headers.Add("Authorization", $"Bearer {tokenString}");

                // Return token and user ID
                return Ok(new { Token = tokenString, user_id = userFromDb.User_id });
            }
            else
            {
                // Invalid credentials, return error message
                return Unauthorized("Invalid username or password");
            }
        }




        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedPassword);
        }

        private string CheckUser(string username, string password)
        {
            // Find the user in the database based on the username
            var user = _appDbContext.Users.FirstOrDefault(u => u.username == username);
            // Check if the user exists and if the password matches
            if (user != null && VerifyPassword(password, user.password))
            {
                return user.User_id.ToString(); // Return the user ID if the user exists and the password matches
            }
            else
            {
                return ""; // Return an empty string if the user doesn't exist or the password doesn't match
            }
        }
        /*private string UserRole(string username, string password)
        {
            // Find the user in the database based on the username
            var user = _appDbContext.Users.FirstOrDefault(u => u.username == username);

            // Check if the user exists and if the password matches
            if (user != null && VerifyPassword(password, user.password))
            {
                

                if (username == "admin")
                {
                    return "admin"; 
                }
                else
                {
                    return "user";
                }
            }
            else
            {
                return ""; 
            }
        }*/

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.password = HashPassword(user.password);
            user.statut = true; // Default status to true

            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();

            return Ok(user);
        }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

      /*  [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest("Invalid user object.");

            if (string.IsNullOrWhiteSpace(userObj.password))
                return BadRequest("Password is required.");
            if (await CheckEmailExistAsync(userObj.email))
                return BadRequest(new { Message = "Email Already Exist" });

            // Vérifiez si le nom d'utilisateur existe déjà
            if (await CheckUsernameExistAsync(userObj.username))
                return BadRequest(new { Message = "Username Already Exist" });

            var passMessage = CheckPasswordStrength(userObj.password);
            if (!string.IsNullOrEmpty(passMessage))
                return BadRequest(new { Message = passMessage });

            // Crypter le mot de passe avec bcrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userObj.password);

            // Remplacer le mot de passe avec le mot de passe crypté
            userObj.password = hashedPassword;

            await _appDbContext.Users.AddAsync(userObj);
            await _appDbContext.SaveChangesAsync();


            // Envoyer un e-mail à l'utilisateur
            await SendWelcomeEmail(userObj.email, userObj.username);
            return Ok(new
            {
                Message = "User Added!",
            });
        }*/
        private async Task SendWelcomeEmail(string email, string nom)
        {
            try
            {
                // Adresse e-mail et mot de passe de l'expéditeur
                string senderEmail = "votre@email.com";
                string password = "votreMotDePasse";

                // Configuration du client SMTP
                using (SmtpClient client = new SmtpClient("smtp.votre-fournisseur-smtp.com"))
                {
                    client.Port = 587;
                    client.Credentials = new NetworkCredential(senderEmail, password);
                    client.EnableSsl = true;

                    // Création du message e-mail
                    MailMessage message = new MailMessage(senderEmail, email)
                    {
                        Subject = "Bienvenue sur notre plateforme",
                        Body = $"Bonjour {nom},\n\nBienvenue sur notre plateforme ! Merci de vous être inscrit.",
                        IsBodyHtml = false,
                    };

                    // Envoi du message
                    await client.SendMailAsync(message);
                }
            }
            catch (SmtpException ex)
            {
                // Gérer les erreurs SMTP
                Console.WriteLine($"Erreur SMTP : {ex.Message}");
                throw; // Propager l'exception pour une gestion ultérieure si nécessaire
            }
            catch (Exception ex)
            {
                // Gérer d'autres exceptions
                Console.WriteLine($"Erreur lors de l'envoi de l'e-mail : {ex.Message}");
                throw; // Propager l'exception pour une gestion ultérieure si nécessaire
            }
        }

        private string CreateJwt(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = GenerateLongKey();

            var identity = new ClaimsIdentity(new Claim[]
            {
        new Claim(ClaimTypes.NameIdentifier, $"{user.User_id}"),
        new Claim(ClaimTypes.Name, $"{user.nom_user}")
            });

            // Récupérer les rôles de l'utilisateur à partir de la table UserRole
            var userRoles = _appDbContext.UserRoles
                                        .Include(ur => ur.Role)
                                        .Where(ur => ur.userId == user.User_id)
                                        .Select(ur => ur.Role)
                                        .ToList();

            foreach (var role in userRoles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.nomRole));
            }

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }


        private string CreateRefreshToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);

            var tokenInUser = _appDbContext.Users
                .Any(a => a.refreshToken == refreshToken);
            if (tokenInUser)
            {
                return CreateRefreshToken();
            }
            return refreshToken;
        }

        private ClaimsPrincipal GetPrincipleFromExpiredToken(string token)
        {
            var key = Encoding.ASCII.GetBytes("veryverysceret.....");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("This is Invalid Token");
            return principal;

        }

        private Task<bool> CheckEmailExistAsync(string? email)
            => _appDbContext.Users.AnyAsync(x => x.email == email);

        private Task<bool> CheckUsernameExistAsync(string? username)
            => _appDbContext.Users.AnyAsync(x => x.email == username);

        private static string CheckPasswordStrength(string pass)
        {
            StringBuilder sb = new StringBuilder();
            if (pass.Length < 9)
                sb.Append("Minimum password length should be 8" + Environment.NewLine);
            if (!(Regex.IsMatch(pass, "[a-z]") && Regex.IsMatch(pass, "[A-Z]") && Regex.IsMatch(pass, "[0-9]")))
                sb.Append("Password should be AlphaNumeric" + Environment.NewLine);
            if (!Regex.IsMatch(pass, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
                sb.Append("Password should contain special charcter" + Environment.NewLine);
            return sb.ToString();
        }
        private byte[] GenerateLongKey()
        {
            // Define your longer key here, for example, using a combination of random bytes
            byte[] key = new byte[32]; // 256 bits
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }
            return key;
        }





    }
}
