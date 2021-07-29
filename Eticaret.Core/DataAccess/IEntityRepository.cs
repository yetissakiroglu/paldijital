using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Eticaret.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T GetOne(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);


    }
}
