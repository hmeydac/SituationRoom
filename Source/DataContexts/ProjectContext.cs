namespace DataContexts
{
    using ProjectEntities;
    using System.Data.Entity;

    public class ProjectContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }
    }
}
