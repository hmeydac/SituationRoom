namespace ProjectEntities.Tests.ObjectMother
{
    using System;
    
    public class TaskTypeMother : ObjectMother<TaskType>
    {
        private const string DefaultDescription = "Test Task Type";

        public TaskTypeMother()
        {
            this.Instance = new TaskType(DefaultDescription);
            this.Instance.Id = new Random(100).Next();
        }
    }
}
