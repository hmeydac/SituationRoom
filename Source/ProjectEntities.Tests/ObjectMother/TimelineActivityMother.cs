namespace ProjectEntities.Tests.ObjectMother
{
    public class TimelineActivityMother : ObjectMother<TimelineActivity>
    {
        private const string DefaultTitle = "Test Activity";

        private object defaultContent = "Content";

        public TimelineActivityMother()
        {
            var author = new TeamMemberMother().Build();
            var timeline = new TimelineMother().Build();
            this.Instance = new TimelineActivity(DefaultTitle, defaultContent, author, timeline);
        }
    }
}