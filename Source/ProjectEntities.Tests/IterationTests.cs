namespace ProjectEntities.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ObjectMother;
    using EntityExceptions;

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
            Assert.IsNotNull(iteration.GetAssignedMembers());
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
        [ExpectedException(typeof(EntityAlreadyExistsException))]
        public void AddExistantDeliverableAgainShouldFail()
        {
            // Arrange
            var iteration = new IterationMother().Build();
            var deliverable = new DeliverableMother().Build();
            var expectedCount = 1;

            // Act
            try
            {
                iteration.AddDeliverable(deliverable);
                iteration.AddDeliverable(deliverable);
            }
            catch (Exception)
            {
                var actualCount = iteration.GetDeliverables().Count();
                Assert.AreEqual(expectedCount, actualCount);
                throw;
            }            
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

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void RemoveInexistentDeliverableShouldFail()
        {
            // Arrange
            var iteration = new IterationMother().Build();
            var deliverable = new DeliverableMother().Build();

            // Act
            iteration.RemoveDeliverable(deliverable.Id);
        }

        [TestMethod]
        public void AssignMemberToIterationTest()
        {
            // Arrange
            var iteration = new IterationMother().Build();
            var teamMember = new TeamMemberMother().Build();
            var originalCount = iteration.GetAssignedMembers().Count();
            var expectedCount = 1;

            // Act
            iteration.AssignTeamMember(teamMember);
            var actual = iteration.GetAssignedMember(teamMember.Id);
            var actualCount = iteration.GetAssignedMembers().Count();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(originalCount, actualCount);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityAlreadyExistsException))]
        public void AssignExistingMemberToIterationShouldFail()
        {
            // Arrange
            var iteration = new IterationMother().Build();
            var teamMember = new TeamMemberMother().Build();
            var expectedCount = 1;

            // Act
            try
            {
                iteration.AssignTeamMember(teamMember);
                iteration.AssignTeamMember(teamMember);
            }
            catch (Exception)
            {
                var actualCount = iteration.GetAssignedMembers().Count();

                // Assert
                Assert.AreEqual(expectedCount, actualCount);
                throw;
            }
        }

        [TestMethod]
        public void UnassignMemberFromIterationTest()
        {
            // Arrange
            var iteration = new IterationMother().Build();
            var teamMember = new TeamMemberMother().Build();
            iteration.AssignTeamMember(teamMember);
            var originalCount = iteration.GetAssignedMembers().Count();
            var expectedCount = 0;

            // Act
            iteration.UnassignTeamMember(teamMember.Id);
            var actualCount = iteration.GetAssignedMembers().Count();
            var actual = iteration.GetAssignedMember(iteration.Id);

            // Assert
            Assert.IsNull(actual);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(originalCount, actualCount);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void UnassignInexistentTeamMemberShouldFail()
        {
            // Arrange
            var iteration = new IterationMother().Build();
            var teamMember = new TeamMemberMother().Build();

            // Act            
            iteration.UnassignTeamMember(teamMember.Id);
        }
    }
}
