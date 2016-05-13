using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Domain;

namespace BudgetManager.Business
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBudgetManagerDbContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        private readonly IBudgetManagerDbContext _context;
    }
}
