namespace ProjectEntities.Tests.ObjectMother
{
    using System;

    public class ProjectMother : ObjectMother<Project>
    {
        private const string defaultName = "Test Project";

        public ProjectMother()
        {            
            this.Instance = new Project(defaultName);
            this.Instance.Id = new Random(100).Next();
        }
    }
}
