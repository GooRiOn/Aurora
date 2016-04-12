using System;
using System.Linq.Expressions;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.DataAccess.Entities.Interfaces;
using Microsoft.Data.Entity;

namespace Aurora.DataAccess.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class, IInternalEntity
    {
        private readonly AuroraContext _context;

        public WriteRepository(AuroraContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateAttached<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertySelector)
        {
            _context.Attach(entity);

            var entry = _context.Entry(entity);

            entry.Property(propertySelector).IsModified = true;
        }

        public void Delete(TEntity entity)
        {
            var softDeletableEntity = entity as ISoftDeletable;

            if(softDeletableEntity == null)
                throw new NotSupportedException("Entity must implement ISoftDeletable interface");

            softDeletableEntity.Delete();
        }
    }
}
