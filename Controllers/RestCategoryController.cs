using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
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

            if (id != category.Code)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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