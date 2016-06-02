using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManager.Domain.ContextConfiguration
{
    internal class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            this.ToTable("Account", BudgetManagerDbContext.AppSchemaName);
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasMany(x => x.Transactions).WithRequired(x => x.Account).HasForeignKey(x => x.AccountId);
        }
    }
}
