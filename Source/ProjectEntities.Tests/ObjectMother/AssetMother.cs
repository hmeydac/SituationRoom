namespace ProjectEntities.Tests.ObjectMother
{
    using System;

    public class AssetMother : ObjectMother<Asset>
    {
        private const string defaultName = "Test Asset";

        public AssetMother()
        { 
            var project = new ProjectMother().Build();
            this.Instance = new Asset(defaultName, project);
            this.Instance.Id = new Random(100).Next();
        }
    }
}
