using Courses.Core.models;

namespace Courses.API.models
{
    public class SingerPostModel
    {
        //public int Id { get; set; }
        public string Subject { get; set; }
        public int MaxCount { get; set; }
        public int CurrentCount { get; set; }
        public EDayOfWeek Day { get; set; }
        public int GuideId { get; set; }
    }
}
