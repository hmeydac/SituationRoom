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

        public DbSet<TaskType> TaskTypes { get; set; }

        public DbSet<Deliverable> Deliverables { get; set; }

        public DbSet<Iteration> Iterations { get; set; }

        public DbSet<Timeline> Timelines { get; set; }

        public DbSet<TimelineActivity> TimelineActivities { get; set; }
    }
}
