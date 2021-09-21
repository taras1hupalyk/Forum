using Forum.DataAccess.Entities;
using Forum.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }


        public async  Task<Category> GetCategoryById(Guid id)
        {
            var result = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
