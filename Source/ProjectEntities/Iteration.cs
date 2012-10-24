namespace ProjectEntities
{
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
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        protected List<Deliverable> Deliverables { get; set; }

        public IEnumerable<Deliverable> GetDeliverables()
        {
            return this.Deliverables;
        }

        public void AddDeliverable(Deliverable deliverable)
        {
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
                throw new Exception("Unable to remove. Deliverable not found.");
            }

            this.Deliverables.Remove(deliverable);
        }
    }
}
