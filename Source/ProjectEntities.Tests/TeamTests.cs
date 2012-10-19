namespace ProjectEntities.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void ConstructTeamTest()
        {
            // Arrange
            var expected = "Test Team";            

            // Act
            var team = new Team(expected);
            var actual = team.Name;
            
            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(team.Workers);
            Assert.IsInstanceOfType(team.Workers, typeof(List<Worker>));
        }

        [TestMethod]
        public void TeamNameTest()
        {
            // Arrange
             var originalExpected = "Test Team";
             var team = new Team(originalExpected);
             var newExpected = "Changed Team";

            // Act
             var originalActual = team.Name;
             team.Name = newExpected;
             var newActual = team.Name;

            // Assert
             Assert.AreEqual(originalExpected, originalActual);
             Assert.AreEqual(newExpected, newActual);
        }

        [TestMethod]
        public void TeamIdTest()
        {
            // Arrange
            var teamName = "Test Team";
            var team = new Team(teamName);
            var newExpected = 1;

            // Act
            var originalActual = team.Id;
            team.Id = newExpected;
            var newActual = team.Id;

            // Assert
            Assert.AreEqual(0, originalActual);
            Assert.AreEqual(newExpected, newActual);
        }
    }
}
