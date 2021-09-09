using Forum.BusinessLogic.Models;
using Forum.BusinessLogic.Services.Interfaces;
using Forum.DataAccess;
using Forum.DataAccess.Entities;
using Forum.DataAccess.Repositories;
using Forum.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }



        public async Task<List<User>> GetAllUsersAsync()
        {
            var result = await userRepository.GetAllAsync();
            return result;
        }

        public async Task<User> AddUser(UserDTO userDTO)
        {
            var user = new User()
            {
                Nickname = userDTO.Nickname,
                Role = userDTO.Role
            };
          var result = await userRepository.InsertAsync(user);
            return result;
        }


    }
}
