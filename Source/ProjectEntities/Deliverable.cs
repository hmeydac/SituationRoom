namespace ProjectEntities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Deliverable
    {
        public Deliverable(string name, Iteration iteration)
        {          
            this.Name = name;
            this.Iteration = iteration;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("IterationId")]
        public Iteration Iteration { get; set; }
    }
}
