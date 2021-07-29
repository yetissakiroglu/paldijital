using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Eticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Eticaret.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public TEntity Create(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        // şartı sağlayan eleman yok, ama hata da almazsınız sonuç size 0 döner
        // şartı sağlayan 3 eleman var ama sonuç birden fazla olduğu için hata alırsınız
        // şartı sağlayan tek bir eleman olduğundan hata almaz, sonuç 50'dir.
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        // şartı sağlayan 3 eleman var ama bunlardan ilk elamanı alır, sonuç 30'dur.
        // şartı sağlayan eleman yok, ama hata da almazsınız sonuç size 0 döner
        // şartı sağlayan tek bir eleman olduğundan, sonuç 50'dir.
        public TEntity GetOne(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;

            }
        }
    }

}
