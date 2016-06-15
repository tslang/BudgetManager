using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Domain;

namespace BudgetManager.Business.Models
{
    public class AccountDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bank { get; set; }
        public decimal Amount { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
