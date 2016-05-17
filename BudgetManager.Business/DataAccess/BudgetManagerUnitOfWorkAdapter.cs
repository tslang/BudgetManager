using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using BudgetManager.Domain;

namespace BudgetManager.Business.DataAccess
{
    public class BudgetManagerUnitOfWorkAdapter : IUnitOfWork, IDisposable
    {
        public BudgetManagerUnitOfWorkAdapter(IBudgetManagerDbContext context)
        {
            _Context = context;
        }

        private IBudgetManagerDbContext _Context { get; }

        #region "Dispose"

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region "SaveChanges"

        public int SaveChanges()
        {
            try
            {
                var result = _Context.SaveChanges();
                return result;
            }
            catch (DbEntityValidationException e)
            {
                var errors = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    errors.Add(string.Format(CultureInfo.InvariantCulture,
                        "Entity of type '{0} in state '{1}' has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    errors.AddRange(
                        eve.ValidationErrors.Select(
                            ve =>
                                string.Format(CultureInfo.InvariantCulture, "- Property: '{0}', Error: '{1}'",
                                    ve.PropertyName, ve.ErrorMessage)));
                }
                foreach (var error in errors)
                {
                    Debug.WriteLine(error);
                }
                throw;
            }
        }

        #endregion

        #region "SetModified"
        public void SetModified<TEntity>(TEntity entity)
            where TEntity : class
        {
            var dbContext = _Context as DbContext;
            if (dbContext != null)
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }
        }
        #endregion

        #region "IsEntityLoaded"
        public bool IsEntityLoaded<TEntity>(TEntity entity)
            where TEntity : class
        {
            var dbContext = _Context as DbContext;
            if (dbContext == null)
            {
                return false;
            }
            var context = dbContext;
            return context.Set<TEntity>().Local.Any(e => e == entity);
        }
        #endregion

        #region "Dispose"
        public virtual void Dispose(bool disposing)
        {
            if (disposing != true)
            {
                return;
            }

            var context = _Context as IDisposable;
            if (context != null)
            {
                context.Dispose();
            }
        }
        #endregion
    }
}