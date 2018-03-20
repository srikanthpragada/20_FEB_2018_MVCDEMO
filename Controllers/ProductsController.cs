using mvcdemo.Models;
using mvcdemo.Models.adonet;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class ProductsController : Controller
    {

        public ActionResult List()
        {
            // Get data from PRODUCTS table
            ViewBag.Message = "";
            var products = new List<Product>();
            SqlConnection con = new SqlConnection(Database.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from products", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Convert row to Product object
                    Product p = new Product
                    {
                        Id = Int32.Parse(dr["prodid"].ToString()),
                        Name = dr["prodname"].ToString(),
                        Price = Decimal.Parse(dr["price"].ToString())
                    };

                    products.Add(p);
                }

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

            return View(products);
        }


        [HttpGet]
        public ActionResult Delete(String id)
        {
            // Delete product with given id 
            SqlConnection con = new SqlConnection(Database.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand
                    ("delete from products where prodid = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle error 
                HttpContext.Trace.Write("Error in ProductController.Delete() : " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Add()
        {
            Product p = new Product();
            p.Category = "ph";
            return View(p);
        }

        [HttpPost]
        public ActionResult Add(Product prod)
        {
            if (!ModelState.IsValid)
            {
                return View(prod);
            }

            // Validate data with custom business logic 


            // Add prod to Products table as a row 
            ViewBag.Message = "";
            SqlConnection con = new SqlConnection(Database.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand
                    ("insert into products (prodname,price,catcode,qoh) values(@name,@price,@catcode,0)", con);
                cmd.Parameters.AddWithValue("@name", prod.Name);
                cmd.Parameters.AddWithValue("@price", prod.Price);
                cmd.Parameters.AddWithValue("@catcode", prod.Category);
                int count = cmd.ExecuteNonQuery();
                if (count == 1)
                {
                    ViewBag.Message = "Product has been added successfully!";
                    ModelState.Clear();  // Clear form 
                    prod = new Product();
                }
            }
            catch (Exception ex)
            {
                // Handle error 
                HttpContext.Trace.Write("Error in ProductController.Add() : " + ex.Message);
                ViewBag.Message = "Sorry! Could not add product due to an error!";
            }
            finally
            {
                con.Close();
            }

            return View(prod);
        }
    }
}