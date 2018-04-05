using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcdemo.Models.ef;

namespace mvcdemo.Controllers
{
    public class CategoriesController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string text)
        {
            var result = from c in db.Categories
                         where c.Code.Contains(text) || c.Description.Contains(text)
                         select c;

            return PartialView("_search",result);
        }


        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ViewBag.Message = "Database Error : " + ex.Message; 
                    return View(category);
                }
            }

            return View(category);
        }
        // Returns Yes if given code is present 
        public String Exists(string id)
        {
            if (id == null)
            {
                return "No";
            }
            Category category = db.Categories.Find(id);

            if (category == null)
            {
                return "No";
            }
            return "Yes";
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // 400
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();  // 404
            }
            
            try
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                TempData["Message"] = "Could not delete category : " + id;
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
