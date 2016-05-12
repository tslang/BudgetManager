﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Business.DataAccess;
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
            return _Context.Accounts.ToList();
        }
        #endregion

        #region "GetAccountById"
        public Account GetAccountById(int id)
        {
            return _Context.Accounts.SingleOrDefault(x => x.Id == id);
        }
#endregion
    }
}
