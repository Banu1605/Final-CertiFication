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
    [RoutePrefix("api/task")]
    public class TasksController : ApiController
    {
        private masterEntities db = new masterEntities();

        // GET: api/Tasks
        [Route("GetTasks")]
        public IQueryable<Task> GetTasks()
        {
            return db.Tasks;
        }

        // GET: api/Tasks/5
        [Route("GetTask/id")]
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask(string id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [Route("PutTask/id")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(string id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Task_ID)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // POST: api/Tasks
        [Route("PostTask")]
        [ResponseType(typeof(Task))]
        public IHttpActionResult PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(task);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TaskExists(task.Task_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = task.Task_ID }, task);
        }

        // DELETE: api/Tasks/5
        [Route("DeleteTasks/id")]
        [ResponseType(typeof(Task))]
        public IHttpActionResult DeleteTask(string id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(task);
            db.SaveChanges();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(string id)
        {
            return db.Tasks.Count(e => e.Task_ID == id) > 0;
        }
    }
}