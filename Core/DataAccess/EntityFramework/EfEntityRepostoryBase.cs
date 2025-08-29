using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepostoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added; // Set the state to Added
                addedEntity.Entity.CreateDate = DateTime.Now;
                context.SaveChanges(); // Save changes to the database
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted; // Set the state to Added
                context.SaveChanges(); // Save changes to the database
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // Use SingleOrDefault to return a single entity or null
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? new TContext().Set<TEntity>().ToList() // Return all branches if no filter is provided
                : new TContext().Set<TEntity>().Where(filter).ToList(); 
        }

        public void Update(TEntity entity)
        {

            
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                updatedEntity.Entity.UpdateDate = DateTime.Now;

                context.SaveChanges();
            }
        }
    }
}
