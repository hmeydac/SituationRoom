namespace ProjectEntities.Tests.ObjectMother
{
    using System;

    public class IterationMother : ObjectMother<Iteration>
    {
        private const string DefaultName = "Test Iteration";
        private DateTime defaultStartDate = new DateTime(2012, 10, 22);
        private DateTime defaultEndDate = new DateTime(2012, 10, 26);

        public IterationMother()
        {
            var project = new ProjectMother().Build();
            this.Instance = new Iteration(DefaultName, project);
            this.Instance.Id = new Random(100).Next();
        }
    }
}
