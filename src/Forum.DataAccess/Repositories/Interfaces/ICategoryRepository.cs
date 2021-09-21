using Forum.DataAccess.Entities;
using System;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        public Task<Category> GetCategoryById(Guid id);
    }
}