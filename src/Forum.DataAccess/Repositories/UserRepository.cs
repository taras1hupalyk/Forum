using Forum.DataAccess.Entities;
using Forum.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories
{
    public class UserRepository :  RepositoryBase<User>,  IUserRepository
    {
        private ApplicationDbContext _dbContex;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContex = dbContext;
        }

        public User GetUserByUserName(string userName)
        {
            var user = _dbContex.Users.Where(x => x.UserName == userName).FirstOrDefault();
            return user;
        }
    }
}
