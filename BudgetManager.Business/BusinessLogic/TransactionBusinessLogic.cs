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
        void Update(Transaction transaction);
        void Remove(int transactionId);
        bool DoesAccountAlreadyExist(Transaction transaction);
        Transaction GetAccountDetails(int transactionId);
    }

    public class TransactionBusinessLogic
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

        private ITransactionService TransactionService { get; set; }



    }
}
