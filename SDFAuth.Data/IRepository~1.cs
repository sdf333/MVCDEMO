using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace SDFAuth.Data
{

    public interface IRepository<TEntity>
    {

        TEntity GetById(object id);
        IQueryable<TEntity> Table { get; }

        void Add(TEntity entity);

        void Update(TEntity entity);
        void Update(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TEntity>> updateExpression);

        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> filters);
        void Delete(object id);
        
    }
}
