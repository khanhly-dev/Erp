using Erp.Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Repository.Catalog.BaseRepository
{
     public class BaseRepository<TEntity, TKey, TDbContext> : IBaseRepository<TEntity, TKey, TDbContext> where TEntity : BaseEntity<TKey> where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public async Task<int> Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expresstion)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expresstion);
            return entity;
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> expresstion)
        {
            var listEntity = await _dbSet.Where(expresstion).ToListAsync();
            var c = 3;
            return listEntity;
        }
    }
}
