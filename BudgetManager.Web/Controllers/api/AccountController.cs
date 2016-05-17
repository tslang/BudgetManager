using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BudgetManager.Business.BusinessLogic;
using BudgetManager.Business.Models;
using BudgetManager.Business.Services;
using BudgetManager.Domain;

namespace BudgetManager.Web.Controllers.api
{
    [System.Web.Http.RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IAccountBusinessLogic _accountBusinessLogic;
        private IAccountDataService _accountDataService;

        public AccountController()
        {
            _accountBusinessLogic = new AccountBusinessLogic(new AccountDataService(new BudgetManagerDbContext()));
            _accountDataService = new AccountDataService(new BudgetManagerDbContext());
        }

        public AccountController(IAccountBusinessLogic accountBusinessLogic, IAccountDataService accountDataService)
        {
            _accountBusinessLogic = accountBusinessLogic;
            _accountDataService = accountDataService;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetAll")]
        public IEnumerable<Account> GetAll()
        {
            var accounts = this._accountDataService.GetAllAccounts();
            return accounts;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Edit")]
        public ActionResult Edit(Account account)
        {
            this._accountBusinessLogic.Edit(account);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Get")]
        public IHttpActionResult Get(int id)
        {
            var model = this._accountBusinessLogic.GetAccountDetails(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Create")]
        public ActionResult Create(AccountCreateCommandModel account)
        {
            if (account == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                _accountBusinessLogic.Create(account);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

        }

    }
}
