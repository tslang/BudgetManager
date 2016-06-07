using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BudgetManager.Business.Models
{
    public class AccountEditCommandModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Id is a required field")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be at least one character and not more than 50 in length")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bank is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Bank must be at least one character and not more than 50 in length")]
        public string Bank { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
        public string[] Transactions { get; set; }
    }
}
