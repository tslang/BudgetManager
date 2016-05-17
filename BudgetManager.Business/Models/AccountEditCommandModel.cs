using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Business.Models
{
    public class AccountEditCommandModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bank { get; set; }
        public decimal Amount { get; set; }
        public string[] Transactions { get; set; }
    }
}
