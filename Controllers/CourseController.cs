using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class CourseController : Controller
    {

        public ActionResult Index()
        {
            Course c = new Course
            {
                Title = "Angular",
                Fee = 2000,
                Duration = 15,
                Topics = new string[] { "Data Binding", "Forms", "Ajax" }
            };

            return View(c);
        }

        public ActionResult List()
        {
            Course[] courses = {
                new Course { Title = "Java SE", Duration = 40, Fee = 5000 },
                new Course { Title = "Microsoft.Net", Duration = 50, Fee = 10000 },
                new Course { Title = "Angular", Duration = 20, Fee = 3000 }

            };
            return View(courses);
        }
    }
}