namespace Lampadas.Web.Controllers
{
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

    using Lampadas.Model;

    public class TasksController : ApiController
    {
        private ProjectContext db = new ProjectContext();

        // GET api/Tasks
        public IEnumerable<ProjectTask> GetProjectTasks()
        {
            return db.ProjectTasks.AsEnumerable();
        }

        // GET api/Tasks/5
        public ProjectTask GetProjectTask(int id)
        {
            ProjectTask projecttask = db.ProjectTasks.Find(id);
            if (projecttask == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return projecttask;
        }

        // PUT api/Tasks/5
        public HttpResponseMessage PutProjectTask(int id, ProjectTask projecttask)
        {
            if (ModelState.IsValid && id == projecttask.Id)
            {
                db.Entry(projecttask).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Tasks
        public HttpResponseMessage PostProjectTask(ProjectTask projecttask)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTasks.Add(projecttask);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, projecttask);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = projecttask.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Tasks/5
        public HttpResponseMessage DeleteProjectTask(int id)
        {
            ProjectTask projecttask = db.ProjectTasks.Find(id);
            if (projecttask == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ProjectTasks.Remove(projecttask);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, projecttask);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}