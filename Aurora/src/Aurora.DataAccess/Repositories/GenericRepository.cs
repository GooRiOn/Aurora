using System;
using System.Linq;
using System.Threading.Tasks;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Infrastructure.Entities.Interfaces;
using Microsoft.Data.Entity;

namespace Aurora.DataAccess.Repositories
{
    public abstract class GenericRepository<TEntity,TKey> : IGenericRepository<TEntity,TKey> where TEntity : class, IInternalEntity<TKey>
    {
        public IQueryable<TEntity> Query => _context.Set<TEntity>();

        private readonly AuroraContext _context;

        protected GenericRepository(AuroraContext context)
        {
            _context = context;
        }

        public virtual TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            var softDeletableEntity = entity as ISoftDeletable;

            if(softDeletableEntity == null)
                throw new NotSupportedException("Entity must implement ISoftDeletable interface");

            softDeletableEntity.Delete();
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await Query.SingleOrDefaultAsync(entiity => entiity.Id.Equals(id));
        }
    }
}
