using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class HelloController : Controller
    {
       
        // Action  Index 
        public ActionResult Index()
        {
            return Content("Hello World. I am learning ASP.NET MVC");  // ContentResult
        }

        public ActionResult Wish(string name)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.Footer = "Srikanth Technologies";
            return View();  // ViewResult 
        }

        public ActionResult About()
        {
            return Content("ASP.NET MVC Course");
        }
    }
}