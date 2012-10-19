namespace ProjectEntities
{
    using System.ComponentModel.DataAnnotations;

    public class Asset
    {
        public Asset(string assetName, Project project)
        {
            this.Name = assetName;
            this.Project = project;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Project Project { get; set; }
    }
}
