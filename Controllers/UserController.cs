using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvcdemo.Controllers
{
    public class UserController : Controller
    {

        [Authorize]
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string pwd)
        {
            if (pwd == "admin")
            {
                FormsAuthentication.SetAuthCookie("admin", false);
                return RedirectToAction("Home");
            }
            else
                ViewBag.Message = "Sorry! Invaid Login. Try Again!";

            return View();
        }
    }
}