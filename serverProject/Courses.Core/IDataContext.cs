using Courses.Core.models;

namespace Courses.Core
{
    public interface IDataContext
    {
        List<Song> courses { get; set; }
        List<User> students { get; set; }
        List<Singer> guiders { get; set; }
    }
}
