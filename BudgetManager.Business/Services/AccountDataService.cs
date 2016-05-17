using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Business.DataAccess;
using BudgetManager.Business.Models;
using BudgetManager.Domain;

namespace BudgetManager.Business.Services
{
    public interface IAccountDataService
    {
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(int id);
        Account Add(Account account);
        Account Remove(Account account);
        int SaveChanges();
        bool Exists(Expression<Func<Account, bool>> expression);
        Account GetAccountDetails(int accountId);
    }

    public class AccountDataService : DataServiceBase<Account>, IAccountDataService
    {
        public AccountDataService(IBudgetManagerDbContext context)
            : base(new BudgetManagerUnitOfWorkAdapter(context), context.Accounts)
        {
            this._Context = context;
        }

        private IBudgetManagerDbContext _Context { get; set; }

        #region "GetAllAccounts"
        public IEnumerable<Account> GetAllAccounts()
        {
            var query = this._Context.Accounts;
            return query.ToList();
        }
        #endregion

        #region "GetAccountById"
        public Account GetAccountById(int id)
        {
            return _Context.Accounts.SingleOrDefault(x => x.Id == id);
        }
        #endregion

        #region "GetAccountDetails"
        public Account GetAccountDetails(int id)
        {
            return this.SingleOrDefault(entity => id == entity.Id);
        }
        #endregion
    }
}
