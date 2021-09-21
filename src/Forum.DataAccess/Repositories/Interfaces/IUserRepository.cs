using Forum.DataAccess.Entities;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public User GetUserByUserName(string userName);
    }
}