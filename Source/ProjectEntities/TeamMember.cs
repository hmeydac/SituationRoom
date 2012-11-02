namespace ProjectEntities
{
    using System.ComponentModel.DataAnnotations;

    public class TeamMember
    {
        public TeamMember(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double DailyCapacity { get; set; }
    }
}
