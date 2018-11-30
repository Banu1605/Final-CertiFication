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
        public Task GetTaskDetails(string id)
        {
            return db.Tasks.Find(id);
        }
        // PUT: api/Tasks/5
        [Route("PutTask/id")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(string id, Task task,string parent_task)
        {
            Task tsk = new Task();
            if (parent_task == "true")
            {
                tsk = GetTaskDetails(id);
                tsk.Parent_ID = Convert.ToInt32(task.Task_ID);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Task_ID)
            {
                return BadRequest();
            }
            if (parent_task == "true")
            {
                db.Entry(tsk).State = EntityState.Modified;
            }
            else
            {
                db.Entry(task).State = EntityState.Modified;
            }
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
        public IHttpActionResult PostTask(Task task,string parent_task,string user_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //task.Parent_ID = Convert.ToInt32(task.Task_ID);
            db.Tasks.Add(task);
            
            try
            {
                db.SaveChanges();
                if (parent_task == "true")
                {
                    Parent_taskController pc = new Parent_taskController();
                    Parent_task pt = new Parent_task();
                    pt.Parent_ID = Convert.ToInt32(task.Task_ID);
                    pt.Parent_Task1 = task.Task1;
                    pc.PostParent_task(pt);
                    task.Parent_ID = Convert.ToInt32(task.Task_ID);
                    var result = PutTask(task.Task_ID, task, parent_task);
                }
               
               
                    UsersController uc = new UsersController();
                    User usr = uc.GetUserDetails(user_id);

                    usr.Project_ID = task.Project_ID;
                    usr.Task_ID = task.Task_ID;

                    uc.UpdateUser(user_id, usr);
                
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