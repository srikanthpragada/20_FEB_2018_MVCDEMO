using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcdemo.Models.ef
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [Required]
        [MinLength(2)]
        [Column("catcode")]
        public string Code { get; set; }

        [Column("catdesc")]
        [MinLength(3)]
        [Required]
        public string Description { get; set; }
    }
}