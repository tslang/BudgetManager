namespace BudgetManager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BudgetManager.Transaction")]
    public partial class Transaction
    {
        public int Id { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public int AccountId { get; set; }

        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }

        public virtual Account Account { get; set; }

        public virtual Category Category { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
