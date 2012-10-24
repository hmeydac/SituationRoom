namespace DataContexts.Tests
{
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                context.Assets.Count();
                context.Projects.Count();
                context.Tasks.Count();
                context.TeamMembers.Count();
                context.Iterations.Count();
                context.Deliverables.Count();
            }
        }
    }
}
