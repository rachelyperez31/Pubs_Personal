using Microsoft.EntityFrameworkCore;
using Pubs.Domain.Core;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pubs_Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly PubsContext _context;
        private readonly DbSet<TEntity> _entities;

        public BaseRepository(PubsContext context)
        {
            this._context = context;
            _entities = context.Set<TEntity>();
        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this._entities.Any(filter);
        }

        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this._entities.Where(filter).ToList();
        }

        public virtual TEntity GetByID(int ID)
        {
            return this._entities.Find(ID);
        }

        public virtual List<TEntity> GetEntities()
        {
            return this._entities.ToList();
        }

        public virtual void Remove(TEntity entity)
        {
            this._entities.Remove(entity);
            this._context.SaveChanges();
        }

        public virtual void Save(TEntity entity)
        {
            this._entities.Add(entity);
            this._context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            this._entities.Update(entity);
            this._context.SaveChanges();
        }
    }
}
