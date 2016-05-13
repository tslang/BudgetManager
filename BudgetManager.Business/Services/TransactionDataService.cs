using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Business.DataAccess;
using BudgetManager.Domain;


namespace BudgetManager.Business.Services
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int id);
        Transaction Add(Transaction transaction);
        Transaction Remove(Transaction transaction);
        int SaveChanges();
        bool Exists(Expression<Func<Transaction, bool>> expression);
        Transaction GetDetails(int transactionId);
    }

    public class TransactionDataService : DataServiceBase<Transaction>, ITransactionService
    {
        public TransactionDataService(IBudgetManagerDbContext context)
            : base(new BudgetManagerUnitOfWorkAdapter(context), context.Transactions)
        {
            this._Context = context;
        }

        private IBudgetManagerDbContext _Context { get; set; }

        #region "GetAllTransactions"
        public IEnumerable<Transaction> GetAllTransactions()
        {
            var query = _Context.Transactions.Include(x => x.SubCategory).Include(x => x.Category);
            return query.ToList();
        }
        #endregion

        #region "GetTransactionById"
        public Transaction GetTransactionById(int id)
        {
            return _Context.Transactions.SingleOrDefault(x => x.Id == id);
        }

        #endregion

        #region "GetDetails"
        public Transaction GetDetails(int id)
        {
            var transaction = this.SingleOrDefault(entity => id == entity.Id, x => x.Description, x => x.Amount,
                x => x.Account);

            return transaction;
        }
        #endregion
    }
}
