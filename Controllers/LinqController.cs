using mvcdemo.Models.linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class LinqController : Controller
    {
        // GET: Linq
        public ActionResult Index()
        {
            InventoryDataContext ctx = new InventoryDataContext();
            return View( ctx.Products);
        }
    }
}