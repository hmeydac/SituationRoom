namespace ProjectEntities.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TeamMemberTests
    {
        [TestMethod]
        public void TeamMemberConstructorTest()
        {
            // Arrange
            var expectedLastName = "LastName Test";
            var expectedFirstName = "FirstName Test";

            // Act
            var teamMember = new TeamMember(expectedFirstName, expectedLastName);
            var actualLastName = teamMember.LastName;
            var actualFirstName = teamMember.FirstName;

            // Assert
            Assert.AreEqual(expectedLastName, actualLastName);
            Assert.AreEqual(expectedFirstName, actualFirstName);
        }

        [TestMethod]
        public void FirstNameTest()
        {
            // Arrange
            var expectedLastName = "LastName Test";
            var originalExpected = "FirstName Test";
            var teamMember = new TeamMember(originalExpected, expectedLastName);
            var newExpected = "New FirstName";

            // Act
            var originalActual = teamMember.FirstName;
            teamMember.FirstName = newExpected;
            var newActual = teamMember.FirstName;

            // Assert
            Assert.AreEqual(originalExpected, originalActual);
            Assert.AreEqual(newExpected, newActual);
        }

        [TestMethod]
        public void LastNameTest()
        {
            // Arrange
            var originalExpected = "LastName Test";
            var expectedFirstName = "FirstName Test";
            var teamMember = new TeamMember(expectedFirstName, originalExpected);
            var newExpected = "New LastName";

            // Act
            var originalActual = teamMember.LastName;
            teamMember.LastName = newExpected;
            var newActual = teamMember.LastName;

            // Assert
            Assert.AreEqual(originalExpected, originalActual);
            Assert.AreEqual(newExpected, newActual);
        }

        [TestMethod]
        public void TeamMemberIdTest()
        {
            // Arrange
            var teamMemberFirstName = "Test";
            var teamMemberLastName = "TeamMember";
            var teamMember = new TeamMember(teamMemberFirstName, teamMemberLastName);
            var newExpected = 1;

            // Act
            var originalActual = teamMember.Id;
            teamMember.Id = newExpected;
            var newActual = teamMember.Id;

            // Assert
            Assert.AreEqual(0, originalActual);
            Assert.AreEqual(newExpected, newActual);
        }
    }
}
