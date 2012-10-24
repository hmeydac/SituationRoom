namespace ProjectEntities.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ProjectEntities.Tests.ObjectMother;

    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void TaskConstructorTest()
        {
          // Arrange
            var project = new ProjectMother().Build();
            var expectedTaskName = "Task Test";

            // Act
            var task = new Task(expectedTaskName, project);
            var actual = task.TaskName;
            var actualProject = task.AssignedProject;

            // Assert
            Assert.AreEqual(expectedTaskName, actual);
            Assert.AreEqual(project, actualProject);
            Assert.IsNotNull(task.GetAssignedWorkers());
            Assert.IsNotNull(task.GetSubtasks());
        }

        [TestMethod]
        public void AssignTaskTest()
        {
            // Arrange
            var task = new TaskMother().Build();
            var worker = new TeamMemberMother().Build();
            var originalCount = task.GetAssignedWorkers().Count();
            var expectedCount = 1;

            // Act
            task.Assign(worker);
            var actualCount = task.GetAssignedWorkers().Count();
            var actualId = task.GetAssignedWorker(worker.Id).Id;

            // Assert
            Assert.AreEqual(worker.Id, actualId);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(originalCount, actualCount);
        }

        [TestMethod]
        public void AddSubtaskTest()
        {
            // Arrange
            var task = new TaskMother().Build();
            var subTask = new TaskMother().Build();
            var originalCount = task.GetSubtasks().Count();
            var expected = 1;

            // Act
            task.AddSubtask(subTask);
            var actual = task.GetSubtasks().Count();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(originalCount, actual);
        }

        [TestMethod]
        public void RemoveSubtaskTest()
        {
            // Arrange
            var task = new TaskMother().Build();
            var subTask = new TaskMother().Build();
            task.AddSubtask(subTask);
            var originalCount = task.GetSubtasks().Count();
            var expected = 0;

            // Act
            task.RemoveSubtask(subTask.Id);
            var actual = task.GetSubtasks().Count();

            // Arrange
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(originalCount, actual);
        }
    }
}
