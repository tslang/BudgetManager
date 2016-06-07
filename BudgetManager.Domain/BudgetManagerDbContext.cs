using BudgetManager.Domain.ContextConfiguration;

namespace BudgetManager.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public interface IBudgetManagerDbContext
    {
        int SaveChanges();
        IDbSet<Account> Accounts { get; set; }
        IDbSet<Transaction> Transactions { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<SubCategory> SubCategories { get; set; }
    }

    public class BudgetManagerDbContext : DbContext, IBudgetManagerDbContext
    {
        public static BudgetManagerDbContext CreateFromConnectionString(string connectionString)
        {
            return new BudgetManagerDbContext(connectionString);
        }

        public BudgetManagerDbContext()
            : this("name=BudgetManager")
        {

        }

        private BudgetManagerDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        internal const string AppSchemaName = "BudgetManager";

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BudgetManagerDbContext>(null);

            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new TransactionConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new SubCategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Account> Accounts { get; set; }
        public IDbSet<Transaction> Transactions { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<SubCategory> SubCategories { get; set; }
    }
}
