using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Business.DataAccess
{
    public class DbSetRepository<TEntity> where TEntity : class
    {
        public DbSetRepository(IUnitOfWork unitOfWork, IDbSet<TEntity> dbSet)
        {
            this.UnitOfWork = unitOfWork;
            this.DbSet = dbSet;
        }

        protected IUnitOfWork UnitOfWork { get; set; }
        protected IDbSet<TEntity> DbSet { get; set; }

        #region "All"
        public IQueryable<TEntity> All
        {
            get { return this.DbSet.AsQueryable(); }
        }
        #endregion

        #region "Find"
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes == null)
            {
                return this.All.Where(expression);
            }
            return includes.Aggregate(this.All.Where(expression), (current, include) => current.Include(include));
        }
        #endregion

        #region "FirstOrDefault"
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes == null)
            {
                return this.All.FirstOrDefault(expression);
            }

            return
                includes.Aggregate(this.All.Where(expression), (current, include) => current.Include(include))
                    .FirstOrDefault();
        }
        #endregion

        #region "SingleOrDefault"
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes == null)
            {
                return this.All.SingleOrDefault(expression);
            }
            return
                includes.Aggregate(this.All.Where(expression), (current, include) => current.Include(include))
                    .SingleOrDefault();
        }
        #endregion

        #region "Count"
        public int Count(Expression<Func<TEntity, bool>> expression)
        {
            return this.DbSet.Count(expression);
        }
        #endregion

        #region "Exists"
        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return this.DbSet.Any(expression);
        }
        #endregion

        #region "Add"
        public TEntity Add(TEntity item)
        {
            return this.DbSet.Add(item);
        }
        #endregion

        #region "AddRange"
        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            for (int index = 0; index < entities.Count(); index++)
            {
                this.DbSet.Add(entities.ElementAt(index));
            }

            return entities;
        }
        #endregion

        #region "Remove"
        public TEntity Remove(TEntity item)
        {
            return this.DbSet.Remove(item);
        }
        #endregion

        #region "SaveChanges"
        public int SaveChanges()
        {
            return this.UnitOfWork.SaveChanges();
        }
        #endregion

    }
}
