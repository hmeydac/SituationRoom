namespace Lampadas.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Lampadas.Model;

    public class IterationController : ApiController
    {
        private ProjectContext db = new ProjectContext();

        // GET api/Iteration
        public IEnumerable<Iteration> GetIterations()
        {
            return db.Iterations.AsEnumerable();
        }

        // GET api/Iteration/5
        public Iteration GetIteration(int id)
        {
            Iteration iteration = db.Iterations.Find(id);
            if (iteration == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return iteration;
        }

        // PUT api/Iteration/5
        public HttpResponseMessage PutIteration(int id, Iteration iteration)
        {
            if (ModelState.IsValid && id == iteration.Id)
            {
                db.Entry(iteration).State = EntityState.Modified;

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

        // POST api/Iteration
        public HttpResponseMessage PostIteration(Iteration iteration)
        {
            if (ModelState.IsValid)
            {
                db.Iterations.Add(iteration);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, iteration);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = iteration.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Iteration/5
        public HttpResponseMessage DeleteIteration(int id)
        {
            Iteration iteration = db.Iterations.Find(id);
            if (iteration == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Iterations.Remove(iteration);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, iteration);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}