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
            this.Teams = new List<Team>();
            this.Assets = new List<Asset>();
            this.Name = projectName;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        protected List<Team> Teams { get; set; }

        protected List<Asset> Assets { get; set; }

        public void AddTeam(Team team)
        {
            this.Teams.Add(team);
        }

        public Team GetTeam(int id)
        {
            return this.Teams.FirstOrDefault(team => team.Id == id);
        }

        public IEnumerable<Team> GetTeams()
        {
            return this.Teams;
        }

        public void RemoveTeam(int id)
        {
            var team = this.GetTeam(id);
            if (team == null)
            {
                throw new Exception("Unable to remove. Team not found.");
            }

            this.Teams.Remove(team);
        }

        public IEnumerable<Asset> GetAssets()
        {
            return this.Assets;
        }

        public void AddAsset(Asset asset)
        {
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
    }
}
