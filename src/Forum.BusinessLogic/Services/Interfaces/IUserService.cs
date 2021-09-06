using Forum.BusinessLogic.Models;
using Forum.DataAccess.Entities;
using Forum.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(UserDTO user);
        Task<List<User>> GetAllUsersAsync();
    }
}