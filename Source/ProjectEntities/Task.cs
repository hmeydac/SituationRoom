namespace ProjectEntities
{
    using ProjectEntities.EntityExceptions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Task
    {
        public Task(string taskName, TaskType taskType, Project assignedProject)
        {
            this.TaskName = taskName;
            this.TaskType = taskType;
            this.AssignedProject = assignedProject;
            this.TeamMembers = new List<TeamMember>();
            this.Subtasks = new List<Task>();
        }

        public int Id { get; set; }

        public string TaskName { get; set; }

        [ForeignKey("Id")]
        public TaskType TaskType { get; set; }

        public Project AssignedProject { get; set; }

        protected List<TeamMember> TeamMembers { get; set; }

        protected List<Task> Subtasks { get; set; }

        public IEnumerable<TeamMember> GetAssignedMembers()
        {
            return this.TeamMembers;
        }

        public void Assign(TeamMember teamMember)
        {
            if (this.GetAssignedMember(teamMember.Id) != null)
            {
                var message = string.Format("Team Member {0} already assigned to Task {1}.", teamMember.Id, this.Id);
                throw new EntityAlreadyExistsException(message);
            }

            this.TeamMembers.Add(teamMember);
        }

        public TeamMember GetAssignedMember(int id)
        {
            return this.TeamMembers.FirstOrDefault(worker => worker.Id == id);
        }

        public void UnassignTeamMember(int id)
        {
            var teamMember = this.GetAssignedMember(id);
            if (teamMember == null)
            {
                var message = string.Format("Cannot unassign Team Member {0} from Task {1}. Not found.", id, this.Id);
                throw new EntityDoesNotExistsException(message);
            }
        }

        public IEnumerable<Task> GetSubtasks()
        {
            return this.Subtasks;
        }

        public void AddSubtask(Task subTask)
        {
            if (this.GetTask(subTask.Id) != null)
            {
                var message = string.Format("Subtask {0} already exists in Task {1}.", subTask.Id, this.Id);
                throw new EntityAlreadyExistsException(message);
            }

            this.Subtasks.Add(subTask);
        }

        public void RemoveSubtask(int id)
        {
            var subTask = this.GetTask(id);
            if (subTask == null)
            {
                var message = string.Format("Unable to remove subtask {0} from Task {1}. Not found.", id, this.Id);
                throw new EntityDoesNotExistsException (message);
            }

            this.Subtasks.Remove(subTask);
        }

        private Task GetTask(int id)
        {
            return this.Subtasks.FirstOrDefault(task => task.Id == id);
        }
    }
}
