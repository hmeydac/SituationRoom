using System.Collections.Generic;
using System.Linq;
using Lampadas.Model;
using Lampadas.Services.Interfaces;

namespace Lampadas.Services
{
    public class ProjectTaskService : IEntityService<ProjectTask>
    {
        public ProjectTask Get(int id)
        {
            ProjectTask task = null;

            using (var context = new ProjectContext())
            {
                task = context.ProjectTasks.FirstOrDefault(projectTask => task.Id.Equals(id));
            }

            return task;
        }

        public IEnumerable<ProjectTask> GetList()
        {
            using (var context = new ProjectContext())
            {
                return context.ProjectTasks.ToList();
            }
        }

        public void SaveOrUpdate(ProjectTask entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
