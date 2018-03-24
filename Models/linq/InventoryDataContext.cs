using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace mvcdemo.Models.linq
{
    public class InventoryDataContext : DataContext 
    {
        public InventoryDataContext() :
           base(Database.ConnectionString)
        {
        }

        public Table<Product> Products
        {
            get
            {
                return GetTable<Product>();
            }
        }
    }
}