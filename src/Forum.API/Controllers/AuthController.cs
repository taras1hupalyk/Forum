using Forum.API.Settings;
using Forum.BusinessLogic.Models;
using Forum.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly JwtSettings _jwtSettings;

        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp ([FromBody] UserSihnUpDTO userDTO)
        {
            var user = new User
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email
            };
            var userCreatedResult = await _userManager.CreateAsync(user, userDTO.Password);
            if (userCreatedResult.Succeeded)
            {
                return Ok(200);
            }
            return Problem(userCreatedResult.Errors.First().Description, null, 500);
        }


        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserSignInDTO userDTO)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Email == userDTO.Email);
            if (user == null)
            {
                return NotFound("user not found");
            }

            var userSingInResult = await _userManager.CheckPasswordAsync(user, userDTO.Password);
            if (userSingInResult== true)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(GenerateJwt(user,roles));
            }

            return BadRequest("password or password incorrect");
        }

        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Role name should be provided.");
            }

            var newRole = new Role()
            {
                Name = roleName
            };

            var roleResult = await _roleManager.CreateAsync(newRole);

            if (roleResult.Succeeded)
            {
                return Ok();
            }

            return Problem(roleResult.Errors.First().Description, null, 500);
        }

        [HttpPost("User/{userEmail}/Role")]
        public async Task<IActionResult> AddUserToRole(string userEmail, [FromBody] string role)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Email == userEmail);
            var result = await _userManager.AddToRoleAsync(user, role);

            if (result.Succeeded)
            {
                return Ok();
            }
            return Problem(result.Errors.First().Description, null, 500);
        }



        private string GenerateJwt(User user , IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
