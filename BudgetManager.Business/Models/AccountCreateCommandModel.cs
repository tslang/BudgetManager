using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Business.Models
{
    public class AccountCreateCommandModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be at least one character and not more than 50 in length")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be at least one character and not more than 50 in length")]
        public string Bank { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}
