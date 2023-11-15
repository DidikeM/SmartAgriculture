using Microsoft.EntityFrameworkCore;
using SmartAgri.DataAccess.Abstract;
using SmartAgri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<T, TContext> : IEntityRepository<T> where T : class, IEntity, new() where TContext : DbContext, new()
    {
        private readonly IDbContextFactory<TContext> _contextFactory;
        public EfEntityRepositoryBase(IDbContextFactory<TContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (TContext context = _contextFactory.CreateDbContext())
            {
                return context.Set<T>().FirstOrDefault(filter)!;
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null!)
        {
            using (TContext context = _contextFactory.CreateDbContext())
            {
                return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
            }
        }

        public int GetCount(Expression<Func<T, bool>> filter = null!)
        {
            using (TContext context = _contextFactory.CreateDbContext())
            {
                return filter == null ? context.Set<T>().Count() : context.Set<T>().Count(filter);
            }
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            using (TContext context = _contextFactory.CreateDbContext())
            {
                return context.Set<T>().Any(filter);
            }
        }

        public void Add(T entity)
        {
            using (TContext context = _contextFactory.CreateDbContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (TContext context = _contextFactory.CreateDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (TContext context = _contextFactory.CreateDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
