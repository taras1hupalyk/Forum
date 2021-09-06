using Forum.DataAccess.Entities;
using Forum.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private ApplicationDbContext _dbContex;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContex = dbContext;
        }
    }
}
