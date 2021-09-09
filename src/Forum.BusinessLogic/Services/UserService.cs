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

        private IUserRepository some;
        private IUnitOfWork _unitOfWork;

        public UserService(IUserRepository some, IUnitOfWork unitOfWork)
        {
            this.some = some;
            _unitOfWork = unitOfWork;

        }



        public async Task<List<User>> GetAllUsersAsync()
        {

            var result = await some.GetAllAsync();

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
