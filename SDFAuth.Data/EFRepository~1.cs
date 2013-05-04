using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data;
using System.Data.Entity.Infrastructure;
using EntityFramework.Extensions;

namespace SDFAuth.Data
{
   public class EfRepository<TEntity>:IRepository<TEntity> where TEntity:class
   {
       
       protected readonly DbContext _context;
       private  DbSet<TEntity> _entities;

       public EfRepository(DbContext context)
       {
           this._context = context;	
	   }

       public virtual IQueryable<TEntity> Table
       {
           get
           {
               return this.Entities;
           }
       }

       protected DbSet<TEntity> Entities
       {
           get { return _entities ?? (_entities = _context.Set<TEntity>()); }
       }

     
       public TEntity GetById(object id)
       {
           return this.Entities.Find(id);
       }

      
       public void Add(TEntity entity)
       {
           if (entity == null)
               throw new ArgumentNullException("entity");
           this.Entities.Add(entity);
           _context.SaveChanges();
       }

       public void Update(TEntity entity)
       {
           var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }
            _context.SaveChanges();          
       }

       public void Update(Expression<Func<TEntity, bool>> expression,Expression<Func<TEntity, TEntity>> updateExpression)
       {
           Entities.Update(expression,updateExpression);
       }


       public void Delete(TEntity entity)
       {
           if (entity == null)
               throw new ArgumentNullException("entity");
           Entities.Remove(entity);
           _context.SaveChanges();
       }

       public void Delete(Expression<Func<TEntity, bool>> expression)
       {
           //var q = this.Get(expression);
           //foreach (var item in q)
           //{
           //    Entities.Remove(item);
           //}
           //context.SaveChanges();
           this.Entities.Delete(expression);
       }

       public void Delete(object id)
       {
           var item = GetById(id);
           if (item != null)
           {
               _context.Entry(item).State = EntityState.Deleted;
           }
           _context.SaveChanges();
       }

   }
}
