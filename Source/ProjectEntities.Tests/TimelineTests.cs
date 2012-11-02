using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEntities.EntityExceptions;
using ProjectEntities.Tests.ObjectMother;

namespace ProjectEntities.Tests
{
    [TestClass]
    public class TimelineTests
    {
        [TestMethod]
        public void TimelineConstructorTest()
        {
            // Act
            var timeline = new Timeline();
            var actual = timeline.GetActivities();

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void AddActivityTest()
        {
            // Arrange
            var activity = new TimelineActivityMother().Build();
            var timeline = new TimelineMother().Build();
            var originalCount = timeline.GetActivities().Count;
            const int expectedCount = 1;

            // Act
            timeline.AddActivity(activity);
            var actual = timeline.GetActivity(activity.Id);
            var actualCount = timeline.GetActivities().Count;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(originalCount, actualCount);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityAlreadyExistsException))]
        public void AddSameActivityShouldFail()
        {
             // Arrange
            var activity = new TimelineActivityMother().Build();
            var timeline = new TimelineMother().Build();
            var originalCount = timeline.GetActivities().Count;
            const int expectedCount = 1;

            // Act
            try
            {
                timeline.AddActivity(activity);
                timeline.AddActivity(activity);
            }catch (Exception)
            {
                var actualCount = timeline.GetActivities().Count;
                
                // Assert
                Assert.AreEqual(expectedCount, actualCount);
                throw;
            }
        }

        [TestMethod]
        public void GetActivityTest()
        {
            // Arrange
            var activity = new TimelineActivityMother().Build();
            var timeline = new TimelineMother().Build();
            timeline.AddActivity(activity);

            // Act
            var actual = timeline.GetActivity(activity.Id);

            // Assert
            Assert.AreSame(activity, actual);
        }

        [TestMethod]
        public void RemoveActivityTest()
        {
            // Arrange
            var activity = new TimelineActivityMother().Build();
            var timeline = new TimelineMother().Build();
            timeline.AddActivity(activity);
            var originalCount = timeline.GetActivities().Count;
            const int expectedCount = 0;

            // Act
            timeline.RemoveActivity(activity.Id);
            var actual = timeline.GetActivity(activity.Id);
            var actualCount = timeline.GetActivities().Count;

            // Assert
            Assert.IsNull(actual);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(originalCount, actualCount);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDoesNotExistsException))]
        public void RemoveInexistentActivityShouldFail()
        {
            // Arrange
            var activity = new TimelineActivityMother().Build();
            var timeline = new TimelineMother().Build();

            // Act
            timeline.RemoveActivity(activity.Id);
        }
    }
}
