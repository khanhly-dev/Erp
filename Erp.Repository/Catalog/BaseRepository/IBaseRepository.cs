using Erp.Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Repository.Catalog.BaseRepository
{
    public interface IBaseRepository<TEntity, TKey, TDbContext> where TEntity : BaseEntity<TKey> where TDbContext : DbContext
    {
        Task<int> Create(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(int id);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> expresstion);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> expresstion);
    }
}
