using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcdemo.Models.ef
{
    public class InventoryDbContext : DbContext 
    {
        public InventoryDbContext():
            base(mvcdemo.Models.Database.ConnectionString)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}