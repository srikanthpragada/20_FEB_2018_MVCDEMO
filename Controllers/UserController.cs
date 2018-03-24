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
                // Redirect user to url that user wanted to go to
                return Redirect(Request.QueryString["ReturnUrl"]);  
            }
            else
                ViewBag.Message = "Sorry! Invaid Login. Try Again!";

            return View();
        }
    }
}