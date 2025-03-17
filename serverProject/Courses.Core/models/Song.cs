namespace Courses.Core.models
{
    public enum EDayOfWeek
    {
        sunday = 1, monday = 2, tuesday = 3, wednesday = 4, thursday = 5
    }
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Link { get; set; }

        public int SingerId { get; set; }
        public Singer Singer { get; set; }
        public List<User> users { get; set; }
    }
}
