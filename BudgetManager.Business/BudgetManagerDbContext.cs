using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Business
{
    public interface IBudgetManagerDbContext
    {
        int SaveChanges();
    }

    public class BudgetManagerDbContext : DbContext, IBudgetManagerDbContext
    {

    }
}
