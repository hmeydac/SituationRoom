namespace ProjectEntities
{
    using System.ComponentModel.DataAnnotations;

    public class TaskType
    {
        public TaskType(string description)
        {
            this.Description = description;
        }

        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
