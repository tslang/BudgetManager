using System.Runtime.Serialization.Json;

namespace BudgetManager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BudgetManager.Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Bank { get; set; }

        public decimal Amount { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
