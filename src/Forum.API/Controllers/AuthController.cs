using Forum.BusinessLogic.Models;
using Forum.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpPost("singup")]
        public async Task<IActionResult> SingUp ([FromBody] UserSingUpDTO userDTO)
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


        [HttpPost("singin")]
        public async Task<IActionResult> SingIn([FromBody] UserSingInDTO userDTO)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Email == userDTO.Email);
            if (user == null)
            {
                return NotFound("user not found");
            }

            var userSingInResult = await _userManager.CheckPasswordAsync(user, userDTO.Password);
            if (userSingInResult== true)
            {
                return Ok();
            }

            return BadRequest("password or password incorrect");
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


    }
}
