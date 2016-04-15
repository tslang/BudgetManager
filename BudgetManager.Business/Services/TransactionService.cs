using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Domain.Models;

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

    public class TransactionService : ITransactionService
    {
    }
}
