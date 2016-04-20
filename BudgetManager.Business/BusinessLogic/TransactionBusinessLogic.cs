using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Business.Services;

namespace BudgetManager.Business.BusinessLogic
{
    public interface ITransactionBusinessLogic
    {

    }

    public class TransactionBusinessLogic : ITransactionBusinessLogic
    {
        public TransactionBusinessLogic(ITransactionService transactionService)
        {
            this.TransactionService = transactionService;
        }

        private ITransactionService TransactionService { get; set; }



    }
}
