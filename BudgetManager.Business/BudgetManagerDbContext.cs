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
        public BudgetManagerDbContext()
            : base("name=BudgetManager")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        private const string AppSchemaName = "BudgetManager";

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BudgetManagerDbContext>(null);

            #region "Account"

            modelBuilder.Entity<Account>().ToTable("Account", AppSchemaName);
            modelBuilder.Entity<Account>().HasKey(x => x.Id);
            modelBuilder.Entity<Account>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Account>()
                .HasMany(x => x.Transactions)
                .WithRequired(x => x.Account).HasForeignKey(x => x.AccountId);

            #endregion

            #region "Transaction"
            modelBuilder.Entity<Transaction>().ToTable("Transaction", AppSchemaName);
            modelBuilder.Entity<Transaction>().HasKey(x => x.Id);
            modelBuilder.Entity<Transaction>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Transaction>().HasRequired(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.AccountId);
            //modelBuilder.Entity<Transaction>().HasRequired(x => x.Category)
            //    .WithMany()
            //    .HasForeignKey(x => x.CategoryId);
            //modelBuilder.Entity<Transaction>().HasRequired(x => x.SubCategory)
            //    .WithMany()
            //    .HasForeignKey(x => x.SubCategoryId);


            #endregion

            #region "Category"
            modelBuilder.Entity<Category>().ToTable("Category", AppSchemaName);
            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            #endregion

            #region "SubCategory"
            modelBuilder.Entity<SubCategory>().ToTable("SubCategory", AppSchemaName);
            modelBuilder.Entity<SubCategory>().HasKey(x => x.Id);
            modelBuilder.Entity<SubCategory>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SubCategory>().HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Account> Accounts { get; set; }
        public IDbSet<Transaction> Transactions { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<SubCategory> SubCategories { get; set; }
    }
}
