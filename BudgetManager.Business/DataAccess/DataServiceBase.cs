using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BudgetManager.Business.DataAccess
{
    public abstract class DataServiceBase<TEntity> where TEntity : class
    {
        protected DataServiceBase(IUnitOfWork unitOfWork, IDbSet<TEntity> dbSet)
        {
            Repository = new DbSetRepository<TEntity>(unitOfWork, dbSet);
        }

        protected DbSetRepository<TEntity> Repository { get; }

        #region Find

        protected IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includes)
        {
            return Repository.Find(expression, includes);
        }

        #endregion

        #region Count

        protected int Count(Expression<Func<TEntity, bool>> expression)
        {
            return Repository.Count(expression);
        }

        #endregion

        #region FirstOrDefault

        protected TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includes)
        {
            return Repository.FirstOrDefault(expression, includes);
        }

        #endregion

        #region SingleOrDefault

        protected TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includes)
        {
            return Repository.SingleOrDefault(expression, includes);
        }

        #endregion

        #region Add

        public TEntity Add(TEntity entity)
        {
            return Repository.Add(entity);
        }

        #endregion

        #region AddRange

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            return Repository.AddRange(entities);
        }

        #endregion

        #region Remove

        public TEntity Remove(TEntity entity)
        {
            return Repository.Remove(entity);
        }

        #endregion

        #region SaveChanges

        public int SaveChanges()
        {
            return this.Repository.SaveChanges();
        }

        #endregion

        #region Exists

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return Repository.Exists(expression);
        }

        #endregion
    }
}

