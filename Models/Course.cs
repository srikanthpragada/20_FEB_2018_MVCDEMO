using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class Course
    {
        public string Title { get; set; }
        public int Fee { get; set; }
        public int Duration { get; set; }
        public string[] Topics { get; set; }
    }
}