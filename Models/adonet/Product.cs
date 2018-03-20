using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models.adonet
{
    public class Product
    {

        public int Id { get; set; }
        [Required (ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Range (100, 100000, ErrorMessage = "Invalid Price. Must be between 100 and 100000")]
        public decimal Price { get; set; }

        public string Category { get; set; }

    }
}