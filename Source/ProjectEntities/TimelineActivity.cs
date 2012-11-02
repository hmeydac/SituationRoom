namespace ProjectEntities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TimelineActivity
    {
        public TimelineActivity(string title, object content, TeamMember author, Timeline timeline)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public Timeline Timeline { get; set; }

        public string Title { get; set; }

        public object Content { get; set; }

        public TeamMember Author { get; set; }
    }
}