namespace ProjectEntities.Tests.ObjectMother
{
    using System;

    public class TeamMemberMother : ObjectMother<TeamMember>
    {
        private const string DefaultFirstName = "Test";
        private const string DefaultLastName = "Worker";

        public TeamMemberMother()
        {
            this.Instance = new TeamMember(DefaultFirstName, DefaultLastName);
            this.Instance.Id = new Random(100).Next();
        }
    }
}
