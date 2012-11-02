using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEntities.Tests
{
    [TestClass]
    public class TaskTypeTests
    {
        [TestMethod]
        public void TaskTypeConstructorTests()
        {
            // Arrange
            var expectedDescription = "Test Task Type";

            // Act
            var taskType = new TaskType(expectedDescription);
            var actual = taskType.Description;

            // Assert
            Assert.AreEqual(expectedDescription, actual);
        }
    }
}
