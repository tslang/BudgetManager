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
        void Add(Account account);
        void Update(Account account);
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

        public void Add(Account account)
        {
            this.AccountDataService.Add(account);
            this.AccountDataService.SaveChanges();
        }

        public void Update(Account model)
        {
            var account = this.AccountDataService.GetAccountById(model.Id);
            MapForEdit(account, model);
            this.AccountDataService.SaveChanges();
        }

        public bool DoesAccountAlreadyExist(Account account)
        {
            return this.AccountDataService.Exists(x => x.Name == account.Name && x.Bank == account.Bank);
        }

        public static void MapForEdit(Account source, Account target)
        {
            target.Name = source.Name;
            target.Bank = source.Bank;
            target.Amount = source.Amount;
        }

        public void Remove(int accountId)
        {
            var account = this.AccountDataService.GetAccountById(accountId);
            this.AccountDataService.Remove(account);
        }

        public Account GetAccountDetails(int accountId)
        {
            return this.AccountDataService.GetDetails(accountId);
        }

        private IAccountDataService AccountDataService { get; set; }
    }
}
