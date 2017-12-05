using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSData
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("PointOfSales.Properties.Settings.PosDBConnectionString") 
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
