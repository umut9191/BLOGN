﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Services.IServices
{
    public interface IService<T> where T : class
    {
        Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = null);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
            string includeProperties = null);
        Task<T> Get(int id);
        Task<bool> Add(T entity);
        T Update(T entity);
        Task<bool> Delete(int id);
    }
}
