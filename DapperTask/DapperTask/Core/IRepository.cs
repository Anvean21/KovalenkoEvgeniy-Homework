using DapperTask.Core.Entities;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DapperTask.Core
{
    public interface IRepository<TEntity> where TEntity : BasicEntity
    {
        TEntity Find(int id);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, object>> expression, object value);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(int entityId);

    }
}
