namespace ProjectEntities.Tests.ObjectMother
{
    using System;

    public class AssetMother : ObjectMother<Asset>
    {
        private const string DefaultName = "Test Asset";

        public AssetMother()
        { 
            var project = new ProjectMother().Build();
            this.Instance = new Asset(DefaultName, project);
            this.Instance.Id = new Random(100).Next();
        }
    }
}
