namespace ProjectEntities.Tests.ObjectMother
{
    using System;

    public class ProjectMother : ObjectMother<Project>
    {
        private const string DefaultName = "Test Project";

        public ProjectMother()
        {            
            this.Instance = new Project(DefaultName);
            this.Instance.Id = new Random(100).Next();
        }
    }
}
