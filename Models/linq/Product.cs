using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace mvcdemo.Models.linq
{
    [Table(Name = "products")]
    public class Product
    {
            [Column(Name = "prodid", IsPrimaryKey = true, IsDbGenerated = true)]
            public int Id { get; set; }

            [Column(Name = "prodname")]
            public string Name { get; set; }

            [Column(Name = "Price")]
            public decimal Price { get; set; }

            [Column(Name = "Qoh")]
            public int Qoh { get; set; }

            [Column(Name = "CatCode")]
            public string Category { get; set; }
    }
}