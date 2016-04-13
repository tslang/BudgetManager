using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Domain.Models
{
    public class SubCategory
    {
        #region Scalar Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
#endregion

        #region Navigation Properties
        public virtual Category Category { get; set; }
        #endregion

    }
}
