using Courses.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<Song> GetList();
        public Song GetById(int id);
        public Song Add(Song course);
        public void Update(int id, Song course);
        public void UpdateStatus(int id, bool status);
    }
}
