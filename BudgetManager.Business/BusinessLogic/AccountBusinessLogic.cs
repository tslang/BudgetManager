using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Business.Models;
using BudgetManager.Business.Services;
using BudgetManager.Domain;

namespace BudgetManager.Business.BusinessLogic
{
    public enum AccountResultCode
    {
        None = 0,
        Okay = 1,
        InvalidItem = -1,
        InvalidPersonId = -2,
        ItemNotFound = -3,
        NullItemInput = -4,
        Error = -5,
        DbValidationError = -6,
        AccountAlreadyExists = -7,
        AlreadySubscribed = -8,
        NotSubscribed = -9,
        InvalidUpdate = -10,

    }

    public interface IAccountBusinessLogic
    {
        void Create(AccountCreateCommandModel account);
        void Edit(Account account);
        void Remove(int accountId);
        bool DoesAccountAlreadyExist(Account account);

    }

    public class AccountBusinessLogic : IAccountBusinessLogic
    {
        public AccountBusinessLogic(IAccountDataService accountDataService)
        {
            this.AccountDataService = accountDataService;
        }

        #region "Create"
        public void Create(AccountCreateCommandModel model)
        {
            var item = AccountBusinessLogic.MapForCreate(model);
            this.AccountDataService.Add(item);
            this.AccountDataService.SaveChanges();
        }
        #endregion

        #region"MapForCreate"
        public static Account MapForCreate(AccountCreateCommandModel source)
        {
            var target = new Account()
            {
                Name = source.Name,
                Bank = source.Bank,
                Amount = source.Amount
            };
            return target;
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

        private IAccountDataService AccountDataService { get; set; }

        public static IDictionary<AccountResultCode, string> ErrorMessages = new Dictionary<AccountResultCode, string>
                                                                                 {
                                                                                     { AccountResultCode.None, String.Empty },
                                                                                     { AccountResultCode.Okay, String.Empty },
                                                                                     { AccountResultCode.InvalidItem, "Invalid Item." },
                                                                                     { AccountResultCode.InvalidPersonId, "Invalid Person Id." },
                                                                                     { AccountResultCode.ItemNotFound, "The item was not found." },
                                                                                     { AccountResultCode.Error, "Unexpected error." },
                                                                                     { AccountResultCode.NullItemInput, "No requisition object was provided." },
                                                                                     { AccountResultCode.AccountAlreadyExists, "That Account already exists." },
                                                                                     { AccountResultCode.DbValidationError, "A database validation error occurred" },
                                                                                     { AccountResultCode.AlreadySubscribed, "This person is already subscribed to the application" },
                                                                                     { AccountResultCode.NotSubscribed, "This person is not subscribed to the application" },
                                                                                     { AccountResultCode.InvalidUpdate, "This account does not have this update." },
                                                                                 };
    }
}
