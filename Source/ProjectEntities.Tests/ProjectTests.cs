namespace ProjectEntities.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ProjectEntities.Tests.ObjectMother;
    
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

        [TestMethod]
        public void AddIterationToProjectTest()
        {
            // Arrange
            var project = new ProjectMother().Build();
            var iteration = new IterationMother().Build();
            var originalCount = project.GetIterations().Count();
            var expectedCount = 1;
            
            // Act
            project.AddIteration(iteration);
            var actual = project.GetIteration(iteration.Id);
            var actualCount = project.GetIterations().Count();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(originalCount, actualCount);            
        }
    }
}
