﻿using System.Data.Entity;

namespace Lampadas.Model
{
    public class ProjectContext : DbContext
    {
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        public DbSet<Iteration> Iterations { get; set; }
    }
}
