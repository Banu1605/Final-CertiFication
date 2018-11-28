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
    [RoutePrefix("api/project")]
    public class ProjectsController : ApiController
    {
        private masterEntities db = new masterEntities();

        // GET: api/Projects
        [Route("GetProjects")]
        public IQueryable<Project> GetProjects()
        {
            return db.Projects;
        }

        // GET: api/Projects/5
        [Route("GetProject/id")]
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(string id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [Route("PutProject/id")]
        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(string id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Project_ID)
            {
                return BadRequest();
            }

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [Route("PostProject")]
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projects.Add(project);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProjectExists(project.Project_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = project.Project_ID }, project);
        }

        // DELETE: api/Projects/5
        [Route("DeleteProject/id")]
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(string id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(string id)
        {
            return db.Projects.Count(e => e.Project_ID == id) > 0;
        }
    }
}