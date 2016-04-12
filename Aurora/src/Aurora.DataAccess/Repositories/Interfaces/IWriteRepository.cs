using System;
using System.Linq.Expressions;
using Aurora.DataAccess.Entities.Interfaces;

namespace Aurora.DataAccess.Repositories.Interfaces
{
    public interface IWriteRepository<TEntity> where TEntity : class, IInternalEntity
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void UpdateAttached<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertySelector);
        void Delete(TEntity entity);

    }
}