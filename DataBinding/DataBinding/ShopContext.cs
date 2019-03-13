using System;
using System.Data.Entity;
using System.Linq;
namespace DataBinding
{

    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
        }
        public DbSet<Good> Goods { get; set; }
    }
}