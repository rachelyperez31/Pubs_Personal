using Pubs.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Pubs.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        List<TEntity> GetEntities();
        TEntity GetByID(int ID);
        List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
        bool Exists(Expression<Func<TEntity, bool>> filter);
        void Update(TEntity entity);
        void Remove(TEntity entity);

    }
}
