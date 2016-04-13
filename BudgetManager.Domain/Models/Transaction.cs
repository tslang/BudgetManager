using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Domain.Models
{
    public interface ITransaction
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Amount { get; set; }
        int AccountId { get; set; }
    }

    public class Transaction : ITransaction
    {
        #region Scalar Properties
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
#endregion

        #region Navigation Properties
        public virtual Account Account { get; set; }
#endregion
    }

}
