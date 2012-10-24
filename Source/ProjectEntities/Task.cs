namespace ProjectEntities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Task
    {
        public Task(string taskName, Project assignedProject)
        {
            this.TaskName = taskName;
            this.AssignedProject = assignedProject;
            this.Workers = new List<TeamMember>();
            this.Subtasks = new List<Task>();
        }

        public int Id { get; set; }

        public string TaskName { get; set; }

        public Project AssignedProject { get; set; }

        protected List<TeamMember> Workers { get; set; }

        protected List<Task> Subtasks { get; set; }

        public IEnumerable<TeamMember> GetAssignedWorkers()
        {
            return this.Workers;
        }

        public void Assign(TeamMember worker)
        {
            this.Workers.Add(worker);
        }

        public TeamMember GetAssignedWorker(int id)
        {
            return this.Workers.FirstOrDefault(worker => worker.Id == id);
        }

        public IEnumerable<Task> GetSubtasks()
        {
            return this.Subtasks;
        }

        public void AddSubtask(Task subTask)
        {
            this.Subtasks.Add(subTask);
        }

        public void RemoveSubtask(int id)
        {
            var subTask = this.GetTask(id);
            if (subTask == null)
            {
                throw new Exception("Unable to remove. Task not found.");
            }

            this.Subtasks.Remove(subTask);
        }

        private Task GetTask(int id)
        {
            return this.Subtasks.FirstOrDefault(task => task.Id == id);
        }
    }
}
