using System.Linq;
using Aurora.DataAccess.Entities.Interfaces;
using Aurora.DataAccess.Repositories.Interfaces;
using Microsoft.Data.Entity;

namespace Aurora.DataAccess.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class, IInternalEntity
    {
        public IQueryable<TEntity> Query => _context.Set<TEntity>();

        public IQueryable<TEntity> NoTrackedQuery => _context.Set<TEntity>().AsNoTracking();

        private readonly AuroraContext _context;

        public ReadRepository(AuroraContext context)
        {
            _context = context;
        }
    }
}
