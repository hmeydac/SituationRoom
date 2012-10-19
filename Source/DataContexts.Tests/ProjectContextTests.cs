namespace DataContexts.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Data.Entity;
    using System.Linq;

    [TestClass]
    public class ProjectContextTests
    {
        [TestMethod]
        public void InitializeDatabaseTest()
        {
            Database.SetInitializer<ProjectContext>(new DropCreateDatabaseIfModelChanges<ProjectContext>());
            
            // Arrange
            using (var context = new ProjectContext())
            {
                context.Teams.Count();
                context.Assets.Count();
                context.Projects.Count();
                context.Tasks.Count();
                context.Workers.Count();
            }
        }
    }
}
