using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        public Task DeleteEntityAsync(TEntity entity);
        Task DeleteRangeAsync(List<TEntity> entities);
        public Task<List<TEntity>> GetAllAsync();
        public Task<TEntity> InsertAsync(TEntity entity);
        public Task<List<TEntity>> InsertRangeAsync(List<TEntity> entities);

        
    }
}