using Forum.BusinessLogic.Models;
using Forum.BusinessLogic.Services.Interfaces;
using Forum.DataAccess;
using Forum.DataAccess.Entities;
using Forum.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;


        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<List<User>> GetAllUsersAsync()
        {
            var result = await _unitOfWork.Users.GetAllAsync();
            return result;
        }

        public async Task<User> AddUser(UserDTO userDTO)
        {
            var user = new User()
            {
                Nickname = userDTO.Nickname,
                Role = userDTO.Role
            };
          var result = await _unitOfWork.Users.InsertAsync(user);
            return result;
        }


    }
}
