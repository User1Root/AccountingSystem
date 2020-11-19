using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESMWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ESMWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ESMDBContext _context;
        private readonly JWTSettings _jwtsettings;

        public UsersController(ESMDBContext context,IOptions<JWTSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
        }

        // GET: api/Users/Login     
        [HttpPost("Login")]
        public async Task<ActionResult<UserWithToken>> Login([FromBody] User user)
        { 
            var user1 = await _context.User
                .Where(us => us.UserName == user.UserName && us.UserPassword == user.UserPassword)
                .FirstOrDefaultAsync();

            UserWithToken userWithToken = null;
            if (user1 != null)
            {
                var refreshToken = GenerateRefreshToken();
                user1.Token.Add(refreshToken);
                
                await _context.SaveChangesAsync();

                userWithToken = new UserWithToken(user1);
                userWithToken.RefreshToken = refreshToken.Token1;
            }            
            if (userWithToken == null)
            {
                return Unauthorized();
            }

            userWithToken.AccessToken = GenerateAccessToken(user1.UserId);

            return Ok(userWithToken);
        }
        
        // GET: api/Users/RefreshToken
        [HttpPost("RefreshToken")]
        public async Task<ActionResult<UserWithToken>> RefreshToken([FromBody] RefreshRequest refreshToken)
        {
            var userId = await ValidateRefreshToken(refreshToken.RefreshToken);
            if (userId != null)
            {
                var user = await _context.User.FindAsync(userId);
                if (user == null)
                    return StatusCode(500);

                var userWithToken = new UserWithToken(user);
                userWithToken.AccessToken = GenerateAccessToken(user.UserId);                

                return Ok(userWithToken);
            }
            return Unauthorized();

        }

        private async Task<long?> ValidateRefreshToken(string refreshToken)
        {           
            var refreshTokenUser = await _context.Token.Where(rt => rt.Token1 == refreshToken)
                .OrderByDescending(rt => rt.ExpireDate)
                .FirstOrDefaultAsync();
            if (refreshTokenUser != null && refreshTokenUser.ExpireDate > DateTime.UtcNow)
            {
                return refreshTokenUser.UserId;
            }
            return null;
        }

        //пока не удалил. Может пригодится.
        private async Task<User> GetUserFromAccessToken(string accessToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false
            };

            try
            {
                SecurityToken securityToken;

                var principle = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userId = principle.FindFirst(ClaimTypes.Name).Value;

                    var user = await _context.User.Where(usr => usr.UserId == Convert.ToInt64(userId)).FirstOrDefaultAsync();
                    return user;
                }
                else
                    return null;
            }
            catch(ArgumentNullException)
            {
                return null;
            }
        }

        private Token GenerateRefreshToken()
        {
            Token refreshToken = new Token();
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create()) 
            {
                rng.GetBytes(randomNumber);
                refreshToken.Token1 = Convert.ToBase64String(randomNumber);
            }
            refreshToken.ExpireDate = DateTime.UtcNow.AddDays(12);
            return refreshToken;
        }

        private string GenerateAccessToken(long userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,Convert.ToString(userId))
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        /* // GET: api/Users
       [HttpGet]
       public async Task<ActionResult<IEnumerable<User>>> GetUsers()
       {
           return await _context.User.ToListAsync();
       }

       // GET: api/Users/5
       [HttpGet("{id}")]
       public async Task<ActionResult<User>> GetUser(long id)
       {
           var user = await _context.User.FindAsync(id);

           if (user == null)
           {
               return NotFound();
           }

           return user;
       }

       // GET: api/Users/5
       [HttpGet("GetUser")]
       public async Task<ActionResult<User>> GetUser()
       {
           string userName = HttpContext.User.Identity.Name;
           var user = await _context.User
               .Where(user => user.UserName == userName)
               .FirstOrDefaultAsync();

           if (user == null)
           {
               return NotFound();
           }
           user.UserPassword = null;
           return user;
       }
         // PUT: api/Users/5
       [HttpPut("{id}")]
       public async Task<IActionResult> PutUser(long id, User user)
       {
           if (id != user.UserId)
           {
               return BadRequest();
           }

           _context.Entry(user).State = EntityState.Modified;

           try
           {
               await _context.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!UserExists(id))
               {
                   return NotFound();
               }
               else
               {
                   throw;
               }
           }

           return NoContent();
       }

       // POST: api/Users
       [HttpPost]
       public async Task<ActionResult<User>> PostUser(User user)
       {
           _context.User.Add(user);
           await _context.SaveChangesAsync();

           return CreatedAtAction("GetUser", new { id = user.UserId }, user);
       }

       // DELETE: api/Users/5
       [HttpDelete("{id}")]
       public async Task<ActionResult<User>> DeleteUser(long id)
       {
           var user = await _context.User.FindAsync(id);
           if (user == null)
           {
               return NotFound();
           }

           _context.User.Remove(user);
           await _context.SaveChangesAsync();

           return user;
       }
        private bool UserExists(long id)
       {
           return _context.User.Any(e => e.UserId == id);
       }
        */
    }
}
