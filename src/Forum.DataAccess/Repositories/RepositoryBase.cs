using Forum.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories
{
    public abstract class RepositoryBase<TEntity> :  IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }


        public async Task<List<TEntity>> InsertRangeAsync(List<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

            return entities;
        }

        public async Task DeleteEntityAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}