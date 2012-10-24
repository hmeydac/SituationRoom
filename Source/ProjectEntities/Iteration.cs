namespace ProjectEntities
{
    using ProjectEntities.EntityExceptions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Iteration
    {
        public Iteration(string name, Project project)
        {
            this.Name = name;
            this.Project = project;
            this.Deliverables = new List<Deliverable>();
            this.AssignedMembers = new List<TeamMember>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public Project Project { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        protected List<Deliverable> Deliverables { get; set; }

        protected List<TeamMember> AssignedMembers { get; set; }

        public IEnumerable<Deliverable> GetDeliverables()
        {
            return this.Deliverables;
        }

        public void AddDeliverable(Deliverable deliverable)
        {
            if (this.GetDeliverable(deliverable.Id) != null)
            {
                var message = string.Format("Deliverable {0} already exists in the Iteration {1}.", deliverable.Id, this.Id);
                throw new EntityAlreadyExistsException(message);
            }

            this.Deliverables.Add(deliverable);
        }

        public Deliverable GetDeliverable(int id)
        {
            return this.Deliverables.FirstOrDefault(deliverable => deliverable.Id == id);
        }

        public void RemoveDeliverable(int id)
        {
            var deliverable = this.GetDeliverable(id);
            if (deliverable == null)
            {
                var message = string.Format("Unable to remove Deliverable {0} from Iteration {1}. Not found.", id, this.Id);
                throw new EntityDoesNotExistsException(message);
            }

            this.Deliverables.Remove(deliverable);
        }

        public IEnumerable<TeamMember> GetAssignedMembers()
        {
            return this.AssignedMembers;
        }

        public void AssignTeamMember(TeamMember teamMember)
        {
            if (this.GetAssignedMember(teamMember.Id) != null)
            {
                var message = string.Format("Team Member {0} already assigned to the iteration {1}.", teamMember.Id, this.Id);
                throw new EntityAlreadyExistsException("Team Member already assigned to the iteration.");
            }

            this.AssignedMembers.Add(teamMember);
        }

        public TeamMember GetAssignedMember(int id)
        {
            return this.AssignedMembers.FirstOrDefault(member => member.Id == id);
        }

        public void UnassignTeamMember(int id)
        {
            var teamMember = this.GetAssignedMember(id);
            if (teamMember == null)
            {
                var message = string.Format("Cannot unassign Team Member {0} from Iteration {1}", id, this.Id);
                throw new EntityDoesNotExistsException(message);
            }

            this.AssignedMembers.Remove(teamMember);
        }
    }
}
