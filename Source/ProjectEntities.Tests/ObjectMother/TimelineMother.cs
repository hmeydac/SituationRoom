namespace ProjectEntities.Tests.ObjectMother
{
    public class TimelineMother : ObjectMother<Timeline>
    {
        public TimelineMother()
        {
            this.Instance = new Timeline();
        }
    }
}