using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> InsertAsync(TEntity entity);
        Task<List<TEntity>> InsertRangeAsync(List<TEntity> entities);
    }
}