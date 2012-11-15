using System.ComponentModel.DataAnnotations;

namespace Lampadas.Model
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
