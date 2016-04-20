using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BudgetManager.Business;
using BudgetManager.Business.BusinessLogic;
using BudgetManager.Business.Services;

namespace BudgetManager.Controllers.api
{
    public class TransactionController : ApiController
    {
        private ITransactionBusinessLogic _transactionBusinessLogic;
        private ITransactionService _transactionService;

        public TransactionController()
        {
            _transactionBusinessLogic = new TransactionBusinessLogic(new TransactionService(new BudgetManagerDbContext()));
            _transactionService = new TransactionService(new BudgetManagerDbContext());
        }

        public TransactionController(ITransactionBusinessLogic transactionBusinessLogic, ITransactionService transactionService)
        {
            _transactionBusinessLogic = transactionBusinessLogic;
            _transactionService = transactionService;
        }


    }
}
