using System;
using System.Data.Entity;
using BudgetManager.Domain;

namespace BudgetManager.Business
{
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
        public BudgetManagerDbContext()
            : base("name=BudgetManager")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        private const string AppSchemaName = "BudgetManager";

        public IDbSet<Account> Accounts { get; set; }
        public IDbSet<Transaction> Transactions { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BudgetManagerDbContext>(null);

            #region "Account"

            modelBuilder.Entity<Account>().ToTable("Account", schemaName: AppSchemaName);
            modelBuilder.Entity<Account>().HasKey(account => account.Id);

            #endregion


            #region "Transaction"

            modelBuilder.Entity<Transaction>().ToTable("Transaction", schemaName: AppSchemaName);
            modelBuilder.Entity<Transaction>().HasKey(transaction => transaction.Id)
                .HasRequired(transaction => transaction.Account)
                .WithMany()
                .HasForeignKey(transaction => transaction.AccountId);
            modelBuilder.Entity<Transaction>().HasRequired(transaction => transaction.Category)
                .WithMany()
                .HasForeignKey(transaction => transaction.CategoryId);

            #endregion


            #region "Category"

            modelBuilder.Entity<Category>().ToTable("Category", schemaName: AppSchemaName);
            modelBuilder.Entity<Category>().HasKey(category => category.Id);

            #endregion


            #region "SubCategory"

            modelBuilder.Entity<SubCategory>().ToTable("SubCategory", schemaName: AppSchemaName);
            modelBuilder.Entity<SubCategory>().HasKey(subcategory => subcategory.Id)
                .HasRequired(subcategory => subcategory.Category)
                .WithMany()
                .HasForeignKey(subcategory => subcategory.CategoryId);

            #endregion


            base.OnModelCreating(modelBuilder);

        }
    }
}
