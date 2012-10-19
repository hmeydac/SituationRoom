namespace ProjectEntities.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        public void WorkerConstructorTest()
        {
            // Arrange
            var expectedLastName = "LastName Test";
            var expectedFirstName = "FirstName Test";

            // Act
            var worker = new Worker(expectedFirstName, expectedLastName);
            var actualLastName = worker.LastName;
            var actualFirstName = worker.FirstName;

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
            var worker = new Worker(originalExpected, expectedLastName );
            var newExpected = "New FirstName";

            // Act
            var originalActual = worker.FirstName;
            worker.FirstName = newExpected;
            var newActual = worker.FirstName;

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
            var worker = new Worker(expectedFirstName, originalExpected);
            var newExpected = "New LastName";

            // Act
            var originalActual = worker.LastName;
            worker.LastName = newExpected;
            var newActual = worker.LastName;

            // Assert
            Assert.AreEqual(originalExpected, originalActual);
            Assert.AreEqual(newExpected, newActual);
        }

        [TestMethod]
        public void WorkerIdTest()
        {
            // Arrange
            var workerFirstName = "Test";
            var workerLastName = "Worker";
            var worker = new Worker(workerFirstName, workerLastName);
            var newExpected = 1;

            // Act
            var originalActual = worker.Id;
            worker.Id = newExpected;
            var newActual = worker.Id;

            // Assert
            Assert.AreEqual(0, originalActual);
            Assert.AreEqual(newExpected, newActual);
        }
    }
}
