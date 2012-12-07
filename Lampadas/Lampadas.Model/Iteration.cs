namespace Lampadas.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Iteration
    {
        public Iteration()
        {
            this.Tasks = new List<ProjectTask>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public List<ProjectTask> Tasks { get; set; }
    }
}
