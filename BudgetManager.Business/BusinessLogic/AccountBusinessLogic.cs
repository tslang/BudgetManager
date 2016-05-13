using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Business.Services;
using BudgetManager.Domain;

namespace BudgetManager.Business.BusinessLogic
{
    public interface IAccountBusinessLogic
    {
        void Create(Account account);
        void Edit(Account account);
        void Remove(int accountId);
        bool DoesAccountAlreadyExist(Account account);
        Account GetAccountDetails(int accountId);

    }

    public class AccountBusinessLogic : IAccountBusinessLogic
    {
        public AccountBusinessLogic(IAccountDataService accountDataService)
        {
            this.AccountDataService = accountDataService;
        }

        #region "Create"
        public void Create(Account account)
        {
            this.AccountDataService.Add(account);
            this.AccountDataService.SaveChanges();
        }
        #endregion

        #region "Edit"
        public void Edit(Account model)
        {
            var account = this.AccountDataService.GetAccountById(model.Id);
            MapForEdit(account, model);
            this.AccountDataService.SaveChanges();
        }
        #endregion

        #region "DoesAccountAlreadyExist
        public bool DoesAccountAlreadyExist(Account account)
        {
            return this.AccountDataService.Exists(x => x.Name == account.Name && x.Bank == account.Bank);
        }
        #endregion

        #region "MapForEdit"
        public static void MapForEdit(Account source, Account target)
        {
            target.Name = source.Name;
            target.Bank = source.Bank;
            target.Amount = source.Amount;
        }
        #endregion

        #region "Remove"
        public void Remove(int accountId)
        {
            var account = this.AccountDataService.GetAccountById(accountId);
            this.AccountDataService.Remove(account);
        }
        #endregion

        #region "GetDetails"
        public Account GetAccountDetails(int accountId)
        {
            return this.AccountDataService.GetAccountDetails(accountId);
        }
        #endregion

        private IAccountDataService AccountDataService { get; set; }
    }
}
