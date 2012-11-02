namespace ProjectEntities.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ProjectEntities.Tests.ObjectMother;
    using ProjectEntities.EntityExceptions;    

    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void TaskConstructorTest()
        {
            // Arrange
            var project = new ProjectMother().Build();
            var taskType = new TaskTypeMother().Build();
            var expectedTaskName = "Task Test";

            // Act
            var task = new Task(expectedTaskName, taskType, project);
            var actual = task.TaskName;
            var actualProject = task.AssignedProject;
            var actualTaskType = task.TaskType;

            // Assert
            Assert.AreEqual(expectedTaskName, actual);
            Assert.AreEqual(project, actualProject);
            Assert.AreEqual(taskType, actualTaskType);
            Assert.IsNotNull(task.GetAssignedMembers());
            Assert.IsNotNull(task.GetSubtasks());
        }

        [TestMethod]
        public void AssignTaskTest()
        {
            // Arrange
            var task = new TaskMother().Build();
            var teamMember = new TeamMemberMother().Build();
            var originalCount = task.GetAssignedMembers().Count();
            var expectedCount = 1;

            // Act
            task.Assign(teamMember);
            var actualCount = task.GetAssignedMembers().Count();
            var actualId = task.GetAssignedMember(teamMember.Id).Id;

            // Assert
            Assert.AreEqual(teamMember.Id, actualId);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(originalCount, actualCount);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityAlreadyExistsException))]
        public void AssignAlreadyAssignedTaskShouldFail()
        {
            // Arrange
            var task = new TaskMother().Build();
            var teamMember = new TeamMemberMother().Build();
            var expectedCount = 1;

            // Act
            try
            {
                task.Assign(teamMember);
                task.Assign(teamMember);
            }
            catch (Exception)
            {
                var actual = task.GetAssignedMembers().Count();
                Assert.AreEqual(expectedCount, actual);
                throw;
            }
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
        [ExpectedException(typeof(EntityAlreadyExistsException))]
        public void AddAlreadyExistantSubtaskShouldFail()
        {
            // Arrange
            var task = new TaskMother().Build();
            var subTask = new TaskMother().Build();
            var expected = 1;

            // Act
            try
            {
                task.AddSubtask(subTask);
                task.AddSubtask(subTask);
            }
            catch (Exception)
            {
                var actual = task.GetSubtasks().Count();
                
                // Assert
                Assert.AreEqual(expected, actual);
                throw;
            }
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

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void RemoveInexistentSubtaskShouldFail()
        {
            // Arrange
            var task = new TaskMother().Build();
            var subTask = new TaskMother().Build();

            // Act
            task.RemoveSubtask(subTask.Id);
        }
    }
}
