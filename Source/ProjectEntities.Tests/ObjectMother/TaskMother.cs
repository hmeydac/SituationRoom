namespace ProjectEntities.Tests.ObjectMother
{
    using System;

    public class TaskMother : ObjectMother<Task>
    {
        private const string DefaultName = "Task Test";

        public TaskMother()
        {
            var project = new ProjectMother().Build();
            this.Instance = new Task(DefaultName, project);
            this.Instance.Id = new Random(100).Next();
        }
    }
}
