using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Domain.Models
{
    public enum Categories
    {
        Mortgage = 1,
        Utilities = 2,
        Cable = 3,
        Internet = 4,
        Home = 5,
        Groceries = 6,
        DiningOut = 7,
        Medical = 8,
        Gas = 9,
        // need to add more
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
