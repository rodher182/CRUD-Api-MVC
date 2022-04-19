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
using CRUDApiMVC.Models;

namespace CRUDApiMVC.Controllers
{
    public class DirectorsController : ApiController
    {
        private CRUDApiMVCEntities db = new CRUDApiMVCEntities();

        // GET: api/Directors
        public IQueryable<Director> GetDirector()
        {
            return db.Director;
        }

        // GET: api/Directors/5
        [ResponseType(typeof(Director))]
        public IHttpActionResult GetDirector(int id)
        {
            Director director = db.Director.Find(id);
            if (director == null)
            {
                return NotFound();
            }

            return Ok(director);
        }

        // PUT: api/Directors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDirector(int id, Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != director.Id)
            {
                return BadRequest();
            }

            db.Entry(director).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
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

        // POST: api/Directors
        [ResponseType(typeof(Director))]
        public IHttpActionResult PostDirector(Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Director.Add(director);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = director.Id }, director);
        }

        // DELETE: api/Directors/5
        [ResponseType(typeof(Director))]
        public IHttpActionResult DeleteDirector(int id)
        {
            Director director = db.Director.Find(id);
            if (director == null)
            {
                return NotFound();
            }

            db.Director.Remove(director);
            db.SaveChanges();

            return Ok(director);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DirectorExists(int id)
        {
            return db.Director.Count(e => e.Id == id) > 0;
        }
    }
}