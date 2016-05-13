using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BudgetManager.Business.BusinessLogic;
using BudgetManager.Business.Services;
using BudgetManager.Domain;

namespace BudgetManager.Web.Controllers.api
{
    [System.Web.Http.RoutePrefix("api/Transaction")]
    public class TransactionController : ApiController
    {
        private ITransactionBusinessLogic _transactionBusinessLogic;
        private ITransactionService _transactionService;

        public TransactionController()
        {
            _transactionBusinessLogic = new TransactionBusinessLogic(new TransactionDataService(new BudgetManagerDbContext()));
            _transactionService = new TransactionDataService(new BudgetManagerDbContext());
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetAll")]
        public IEnumerable<Transaction> GetAll()
        {
            var query = _transactionBusinessLogic.GetAllTransactions();
            return query.ToList();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Update")]
        public ActionResult Update(Transaction transaction)
        {
            this._transactionBusinessLogic.Update(transaction);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public Transaction Get(int id)
        {
            var transaction = this._transactionBusinessLogic.GetTransactionDetails(id);
            return transaction;
        }

        public ActionResult Add(Transaction transaction)
        {
            this._transactionBusinessLogic.Add(transaction);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

    }
}
