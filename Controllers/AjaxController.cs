using mvcdemo.Models;
using mvcdemo.Models.adonet;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            return Content(String.Format("Sum = {0}", n1 + n2));
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchProducts(string prodname)
        {
            Thread.Sleep(2000);
            var products = new List<Product>();
            ViewBag.Message = "";
            SqlConnection con = new SqlConnection(Database.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand
                   ("select * from products where prodname like @name", con);
                cmd.Parameters.AddWithValue("@name", "%" + prodname + "%");
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Convert row to Product object
                    Product p = new Product
                    {
                        Id = Int32.Parse(dr["prodid"].ToString()),
                        Name = dr["prodname"].ToString(),
                        Price = Decimal.Parse(dr["price"].ToString()),
                        Category = dr["catcode"].ToString()
                    };
                    products.Add(p);
                }

                if (products.Count == 0)
                    ViewBag.Message = "Sorry! No products found your search!";

            }
            catch (Exception ex)
            {
                // Handle error 
                HttpContext.Trace.Write("Error in ProductController.List() : " + ex.Message);
                ViewBag.Message = "Sorry! Could not retrieve products details!";
            }
            finally
            {
                con.Close();
            }

            return PartialView(products);

        } // SearchProduct 

    }
}