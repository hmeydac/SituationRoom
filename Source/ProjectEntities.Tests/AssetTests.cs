namespace ProjectEntities.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ProjectEntities.Tests.ObjectMother;

    [TestClass]
    public class AssetTests
    {
        [TestMethod]
        public void AssetConstructorTest()
        {
            // Arrangeory
            var expectedName = "Asset Test";
            var project = new ProjectMother().Build();

            // Act
            var asset = new Asset(expectedName, project);
            var actual = asset.Name;

            // Assert
            Assert.AreEqual(expectedName, actual);
        }

        [TestMethod]
        public void AssetNameTest()
        {
            // Arrange
            var originalExpected = "Test Asset";
            var project = new ProjectMother().Build();
            var asset = new Asset(originalExpected, project);
            var newExpected = "Changed Asset";

            // Act
            var originalActual = asset.Name;
            asset.Name = newExpected;
            var newActual = asset.Name;

            // Assert
            Assert.AreEqual(originalExpected, originalActual);
            Assert.AreEqual(newExpected, newActual);
        }
    }
}
