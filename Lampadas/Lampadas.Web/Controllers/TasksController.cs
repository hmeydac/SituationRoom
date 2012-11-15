namespace Lampadas.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Lampadas.Web.Models;

    public class TasksController : ApiController
    {
        private TaskHeader[] tasksHeaders = new TaskHeader[]
                                                {
                                                    new TaskHeader {Id = 1, Title = "Task1"},
                                                    new TaskHeader {Id = 2, Title = "Task2"},
                                                    new TaskHeader {Id = 3, Title = "Task3"},
                                                    new TaskHeader {Id = 4, Title = "Task4"}
                                                };

        public IEnumerable<TaskHeader> GetAllTaskHeaders()
        {
            return tasksHeaders;
        }

        public TaskHeader GetTaskHeaderById(int id)
        {
            var task = tasksHeaders.FirstOrDefault(taskHeader => taskHeader.Id == id);
            if (task == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return task;
        }
    }
}
