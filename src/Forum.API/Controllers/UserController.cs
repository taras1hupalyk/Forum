
using Forum.BusinessLogic.Models;
using Forum.BusinessLogic.Services.Interfaces;
using Forum.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAllUsersAsync();
            return Ok(response);
        }

        

        [HttpGet("user-roles")]
        public async Task<IActionResult> GetUserRoles(string userName)
        {
            var user = _userService.GetUserByUserName(userName);
            var result = await _userManager.GetRolesAsync(user);

            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO user)
        {
           var result = await _userService.AddUser(user);
           return Ok(user);
        }        

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
