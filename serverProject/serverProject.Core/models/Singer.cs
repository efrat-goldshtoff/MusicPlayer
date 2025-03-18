namespace serverProject.Core.models
{
    public class Singer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Song> songs { get; set; }
    }
}
