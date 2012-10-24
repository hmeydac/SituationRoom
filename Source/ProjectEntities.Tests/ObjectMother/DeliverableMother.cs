namespace ProjectEntities.Tests.ObjectMother
{
    using System;

    public class DeliverableMother : ObjectMother<Deliverable>
    {
        private const string DefaultName = "Test Deliverable";

        public DeliverableMother()
        { 
            var iteration = new IterationMother().Build();
            this.Instance = new Deliverable(DefaultName, iteration);
            this.Instance.Id = new Random(100).Next();
        }
    }
}
