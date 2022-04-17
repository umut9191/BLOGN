using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity,bool>> filter=null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy=null,
            string includeProperties=null);
        Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null);
        Task<TEntity> Get(int id);
        Task<bool> Add(TEntity entity);
        TEntity Update(TEntity entity);
        Task<bool> Delete(int id);

    }
}
