﻿using Aurora.DataAccess.Entities.Interfaces;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IEntityService<TEntity> where TEntity : class, IInternalEntity
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}