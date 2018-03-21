using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Now()
        {
            Thread.Sleep(10000);
            return Content(DateTime.Now.ToString());
        }

        public ActionResult Add(int n1, int n2)
        {
            return Content( String.Format("Sum = {0}",n1 + n2) );
        }
    }
}