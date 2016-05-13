using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Business.Models
{
    public class AccountCreateCommandModel
    {
        public string Name { get; set; }
        public string Bank { get; set; }
        public decimal Amount { get; set; }
    }
}
