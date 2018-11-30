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
using FinalCertification.Models;

namespace FinalCertification.Controllers
{
    public class Parent_taskController : ApiController
    {
        private masterEntities db = new masterEntities();

        // GET: api/Parent_task
        public IQueryable<Parent_task> GetParent_task()
        {
            return db.Parent_task;
        }

        // GET: api/Parent_task/5
        [ResponseType(typeof(Parent_task))]
        public IHttpActionResult GetParent_task(int id)
        {
            Parent_task parent_task = db.Parent_task.Find(id);
            if (parent_task == null)
            {
                return NotFound();
            }

            return Ok(parent_task);
        }

        // PUT: api/Parent_task/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParent_task(int id, Parent_task parent_task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parent_task.Parent_ID)
            {
                return BadRequest();
            }

            db.Entry(parent_task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Parent_taskExists(id))
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

        // POST: api/Parent_task
        [ResponseType(typeof(Parent_task))]
        public IHttpActionResult PostParent_task(Parent_task parent_task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parent_task.Add(parent_task);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Parent_taskExists(parent_task.Parent_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = parent_task.Parent_ID }, parent_task);
        }

        // DELETE: api/Parent_task/5
        [ResponseType(typeof(Parent_task))]
        public IHttpActionResult DeleteParent_task(int id)
        {
            Parent_task parent_task = db.Parent_task.Find(id);
            if (parent_task == null)
            {
                return NotFound();
            }

            db.Parent_task.Remove(parent_task);
            db.SaveChanges();

            return Ok(parent_task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Parent_taskExists(int id)
        {
            return db.Parent_task.Count(e => e.Parent_ID == id) > 0;
        }
    }
}