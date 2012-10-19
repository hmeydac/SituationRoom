namespace ProjectEntities.Tests.ObjectMother
{
    using System;

    public class TeamMother : ObjectMother<Team>
    {
        private const string defaultName = "Test Team";

        public TeamMother()
        {
            this.Instance = new Team(defaultName);
            this.Instance.Id = new Random(100).Next();
        }
    }
}
