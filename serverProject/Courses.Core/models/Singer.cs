namespace Courses.Core.models
{
    public class Singer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public List<Song> Courses { get; set; }
    }
}
