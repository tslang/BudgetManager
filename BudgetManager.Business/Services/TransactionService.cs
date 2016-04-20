using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    }

    public class TransactionService : DataServiceBase<Transaction>, ITransactionService
    {
        public TransactionService(IBudgetManagerDbContext context)
            : base(new BudgetManagerUnitOfWorkAdapter(context), context.Transactions)
        {
            this.Context = context;
        }

        private IBudgetManagerDbContext Context { get; set; }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return this.Find(x => true);
        }

        public Transaction GetTransactionById(int id)
        {
            return Context.Transactions.SingleOrDefault(x => x.Id == id);
        }

        

    }
}
