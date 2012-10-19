namespace ProjectEntities.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;    
    using ProjectEntities.Tests.ObjectMother;
    using System.Linq;

    [TestClass]
    public class ProjectTests
    {
        [TestMethod]
        public void ProjectConstructorTest()
        {
            // Arrange
            var expectedName = "Project Test";

            // Act
            var project = new Project(expectedName);
            var actual = project.Name;

            // Assert
            Assert.AreEqual(expectedName, actual);
            Assert.IsNotNull(project.GetAssets());
            Assert.IsNotNull(project.GetTeams());
        }

        [TestMethod]
        public void ProjectNameTest()
        {
            // Arrange
            var originalExpected = "Test Project";
            var project = new Project(originalExpected);
            var newExpected = "Changed Project";

            // Act
            var originalActual = project.Name;
            project.Name = newExpected;
            var newActual = project.Name;

            // Assert
            Assert.AreEqual(originalExpected, originalActual);
            Assert.AreEqual(newExpected, newActual);
        }

        [TestMethod]
        public void ProjectTeamAssignedTest()
        {
            // Arrange
            var project = new ProjectMother().Build();
            var team = new TeamMother().Build();

            // Act
            project.AddTeam(team);
            var actual = project.GetTeam(team.Id);

            // Assert
            Assert.AreEqual(team.Id, actual.Id);
            Assert.AreEqual(team.Name, actual.Name);
        }

        [TestMethod]
        public void RemoveTeamFromProjectTest()
        {            
            // Arrange
            var project = new ProjectMother().Build();
            var team = new TeamMother().Build();
            project.AddTeam(team);
            var originalCount = project.GetTeams().Count();
            var expected = 0;

            // Act            
            project.RemoveTeam(team.Id);
            var actual = project.GetTeams().Count();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(originalCount, actual);
        }

        [TestMethod]
        public void AddAssetToProjectTest()
        {
            // Arrange
            var project = new ProjectMother().Build();
            var asset = new AssetMother().Build();
            var originalCount = project.GetAssets().Count();
            var expectedId = asset.Id;
            var expectedCount = 1;

            // Act
            project.AddAsset(asset);
            var actualAsset = project.GetAsset(asset.Id);
            var actualId = actualAsset.Id;
            var actualCount = project.GetAssets().Count();            

            // Assert
            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(originalCount, actualCount);            
        }

        [TestMethod]
        public void RemoveAssetFromProjectTest()
        {
            // Arrange
            var project = new ProjectMother().Build();
            var asset = new AssetMother().Build();
            project.AddAsset(asset);
            var originalCount = project.GetAssets().Count();
            var expected = 0;

            // Act
            project.RemoveAsset(asset.Id);
            var actual = project.GetAssets().Count();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(originalCount, actual);
        }
    }
}
