using System.Linq;
using AutoMapper;
using Lampadas.Model;
using Lampadas.Services;

namespace Lampadas.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Models;

    public class TasksController : ApiController
    {
        public IEnumerable<TaskHeader> GetAllTaskHeaders()
        {
            var projectTaskService = new ProjectTaskService();
            var tasks = projectTaskService.GetList();
            var headers = new List<TaskHeader>();

            tasks.ToList().ForEach(task => headers.Add(Mapper.Map<ProjectTask, TaskHeader>(task)));
            return headers;
        }
    }
}
