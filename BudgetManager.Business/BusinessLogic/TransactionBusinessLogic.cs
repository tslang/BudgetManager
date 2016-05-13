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
        void Add(Transaction transaction);
        void Update(Transaction model);
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

        public void Add(Transaction transaction)
        {
            this.TransactionService.Add(transaction);
            this.TransactionService.SaveChanges();
        }

        public void Update(Transaction model)
        {
            var transaction = this.TransactionService.GetTransactionById(model.Id);
            MapForEdit(transaction, model);
            this.TransactionService.SaveChanges();
        }

        public bool DoesTransactionAlreadyExist(Transaction transaction)
        {
            return this.TransactionService.Exists(x =>
                        x.Description == transaction.Description && x.Amount == transaction.Amount &&
                        x.SubCategory == transaction.SubCategory && x.Account == transaction.Account);
        }

        public static void MapForEdit(Transaction source, Transaction target)
        {
            target.Description = source.Description;
            target.Amount = source.Amount;
            target.SubCategory = source.SubCategory;
            target.Account = source.Account;
        }

        public void Remove(int transactionId)
        {
            var account = this.TransactionService.GetTransactionById(transactionId);
            this.TransactionService.Remove(account);
        }

        public Transaction GetTransactionDetails(int transactionId)
        {
            return this.TransactionService.GetDetails(transactionId);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return this.TransactionService.GetAllTransactions();
        } 

        private ITransactionService TransactionService { get; set; }



    }
}
