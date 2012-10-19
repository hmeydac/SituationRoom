namespace ProjectEntities.Tests.ObjectMother
{
    using System;

    public class WorkerMother : ObjectMother<Worker>
    {
        private const string defaultFirstName = "Test";
        private const string defaultLastName = "Worker";

        public WorkerMother()
        {
            this.Instance = new Worker(defaultFirstName, defaultLastName);
            this.Instance.Id = new Random(100).Next();
        }
    }
}
