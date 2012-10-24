namespace DataContexts
{
    using System.Data.Entity;
    using ProjectEntities;

    public class ProjectContext : DbContext
    {        
        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }
    }
}
