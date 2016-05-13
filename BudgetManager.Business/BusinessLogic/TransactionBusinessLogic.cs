using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Business.Services;
using BudgetManager.Domain;

namespace BudgetManager.Business.BusinessLogic
{
    public interface ITransactionBusinessLogic
    {
        void Create(Transaction transaction);
        void Edit(Transaction model);
        void Remove(int transactionId);
        bool DoesTransactionAlreadyExist(Transaction transaction);
        Transaction GetTransactionDetails(int transactionId);
        IEnumerable<Transaction> GetAllTransactions();
    }

    public class TransactionBusinessLogic : ITransactionBusinessLogic
    {
        public TransactionBusinessLogic(ITransactionService transactionService)
        {
            this.TransactionService = transactionService;
        }

        #region "Create"
        public void Create(Transaction transaction)
        {
            this.TransactionService.Add(transaction);
            this.TransactionService.SaveChanges();
        }
        #endregion

        #region "Edit"
        public void Edit(Transaction model)
        {
            var transaction = this.TransactionService.GetTransactionById(model.Id);
            MapForEdit(transaction, model);
            this.TransactionService.SaveChanges();
        }
        #endregion

        #region "DoesTransactionAlreadyExist
        public bool DoesTransactionAlreadyExist(Transaction transaction)
        {
            return this.TransactionService.Exists(x =>
                        x.Description == transaction.Description && x.Amount == transaction.Amount &&
                        x.SubCategory == transaction.SubCategory && x.Account == transaction.Account);
        }
        #endregion

        #region "MapForEdit"
        public static void MapForEdit(Transaction source, Transaction target)
        {
            target.Description = source.Description;
            target.Amount = source.Amount;
            target.SubCategory = source.SubCategory;
            target.Account = source.Account;
        }
        #endregion

        #region "Remove"
        public void Remove(int transactionId)
        {
            var account = this.TransactionService.GetTransactionById(transactionId);
            this.TransactionService.Remove(account);
        }
        #endregion

        #region GetTransactionDetails
        public Transaction GetTransactionDetails(int transactionId)
        {
            return this.TransactionService.GetDetails(transactionId);
        }
        #endregion

        #region "GetAllTransaction"
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return this.TransactionService.GetAllTransactions();
        }
        #endregion

        private ITransactionService TransactionService { get; set; }



    }
}
