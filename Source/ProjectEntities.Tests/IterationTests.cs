namespace ProjectEntities.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ProjectEntities.Tests.ObjectMother;

    [TestClass]
    public class IterationTests
    {
        [TestMethod]
        public void IterationConstructorTest()
        {
            // Arrange
            var project = new ProjectMother().Build();
            var expectedIterationName = "Test Iteration";

            // Act
            var iteration = new Iteration(expectedIterationName, project);
            var actual = iteration.Name;
            var actualProject = iteration.Project;

            // Assert
            Assert.AreEqual(expectedIterationName, actual);
            Assert.AreEqual(project, actualProject);
            Assert.IsNotNull(iteration.GetDeliverables());
        }

        [TestMethod]
        public void AddDeliverableToIterationTest()
        {
            // Arrange
            var iteration = new IterationMother().Build();
            var deliverable = new DeliverableMother().Build();
            var originalCount = iteration.GetDeliverables().Count();
            var expectedCount = 1;

            // Act
            iteration.AddDeliverable(deliverable);
            var actual = iteration.GetDeliverable(deliverable.Id);
            var actualCount = iteration.GetDeliverables().Count();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(originalCount, actualCount);
        }

        [TestMethod]
        public void RemoveDeliverableFromIterationTest()
        {
            // Arrange
            var iteration = new IterationMother().Build();
            var deliverable = new DeliverableMother().Build();
            iteration.AddDeliverable(deliverable);
            var originalCount = iteration.GetDeliverables().Count();
            var expectedCount = 0;
            
            // Act
            iteration.RemoveDeliverable(deliverable.Id);
            var actualCount = iteration.GetDeliverables().Count();
            var actual = iteration.GetDeliverable(iteration.Id);

            // Assert
            Assert.IsNull(actual);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(originalCount, actualCount);
        }
    }
}
