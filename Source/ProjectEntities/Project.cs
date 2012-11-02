namespace ProjectEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Project
    {
        public Project(string projectName)
        {        
            this.Assets = new List<Asset>();
            this.Iterations = new List<Iteration>();
            this.Name = projectName;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
           
        protected List<Asset> Assets { get; set; }

        protected List<Iteration> Iterations { get; set; }

        public IEnumerable<Asset> GetAssets()
        {
            return this.Assets;
        }

        public void AddAsset(Asset asset)
        {
            asset.Project = this;
            this.Assets.Add(asset);
        }

        public Asset GetAsset(int id)
        {
            return this.Assets.FirstOrDefault(asset => asset.Id == id);
        }

        public void RemoveAsset(int id)
        {
            var asset = this.GetAsset(id);
            if (asset == null)
            {
                throw new Exception("Unable to remove. Asset not found.");
            }

            this.Assets.Remove(asset);
        }

        public void AddIteration(Iteration iteration)
        {
            this.Iterations.Add(iteration);
        }

        public IEnumerable<Iteration> GetIterations()
        {
            return this.Iterations;
        }

        public Iteration GetIteration(int id)
        {
            return this.Iterations.FirstOrDefault(iteration => iteration.Id == id);
        }
    }
}
