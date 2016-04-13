using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Domain.Models
{
    public interface IAccount
    {
        int Id { get; set; }
        string Name { get; set; }
        string Bank { get; set; }
        int AccountTypeId { get; set; }
        decimal Amount { get; set; }
    }

    public class Account : IAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bank { get; set; }
        public int AccountTypeId { get; set; }
        public decimal Amount { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } 
    }
}
