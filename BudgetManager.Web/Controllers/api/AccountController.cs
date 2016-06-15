using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using BudgetManager.Business.BusinessLogic;
using BudgetManager.Business.Models;
using BudgetManager.Business.Services;
using BudgetManager.Domain;
using Newtonsoft.Json;

namespace BudgetManager.Web.Controllers.api
{
    [System.Web.Http.RoutePrefix("api/Account")]
    public class FinancialAccountController : ApiController
    {
        private IAccountBusinessLogic _accountBusinessLogic;
        private IAccountDataService _accountDataService;

        public FinancialAccountController()
        {
            _accountBusinessLogic = new AccountBusinessLogic(new AccountDataService(new BudgetManagerDbContext()));
            _accountDataService = new AccountDataService(new BudgetManagerDbContext());
        }

        public FinancialAccountController(IAccountBusinessLogic accountBusinessLogic, IAccountDataService accountDataService)
        {
            _accountBusinessLogic = accountBusinessLogic;
            _accountDataService = accountDataService;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetAll")]
        public IEnumerable<Account> GetAll()
        {
            return this._accountDataService.GetAllAccounts();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Get")]
        public IHttpActionResult Get(int id)
        {
            var account = this._accountDataService.GetDetails(id);
            return Ok(account);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Edit")]
        public ActionResult Edit(Account account)
        {
            this._accountBusinessLogic.Edit(account);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Create")]
        public IHttpActionResult Create(AccountCreateCommandModel account)
        {
            if (account == null)
            {
                return NotFound();
            }
            else
            {
                _accountBusinessLogic.Create(account);
                return Ok();
            }

        }

    }
}
