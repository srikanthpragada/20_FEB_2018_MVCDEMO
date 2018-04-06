using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using mvcdemo.Models.ef;

namespace mvcdemo.Controllers
{
    public class RestCategoryController : ApiController
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: api/RestCategory
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/RestCategory/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(string id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/RestCategory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(string id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cat = db.Categories.Find(id);
            if (cat == null)
                return NotFound();

            try
            {
                cat.Description = category.Description;   // Modify
                db.SaveChanges();   // Update is executed 
            }
            catch (Exception ex) 
            {
                HttpContext.Current.Trace.Write("Error in PutCategory : " + ex.InnerException.Message);
                return InternalServerError(ex);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RestCategory
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        // DELETE: api/RestCategory/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(string id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            try
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(string id)
        {
            return db.Categories.Count(e => e.Code == id) > 0;
        }
    }
}