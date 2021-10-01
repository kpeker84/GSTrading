using GSTradingProject.MAP.Options;
using GSTradingProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTradingProject.DAL.Context
{
    public class GSTradingContext:DbContext
    {
        public GSTradingContext() : base("DbConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new ProductOrderMap());
            modelBuilder.Configurations.Add(new ImageMap());
            modelBuilder.Configurations.Add(new PriceCalculationMap());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductOrder> ProductsAndOrders { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PriceCalculation> PriceCalculations { get; set; }
    }
}
