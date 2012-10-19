namespace ProjectEntities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public Team(string name)
        { 
            this.Name = name;
            this.Workers = new List<Worker>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Worker> Workers { get; set; }
    }
}
