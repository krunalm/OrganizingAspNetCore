namespace WithFeatureFolders.Features.Ninjas.Ninjas
{
    public class NinjaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}