using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.models;

namespace Courses.Core.Services
{
    public interface IUserService
    {
        public IEnumerable<Song> GetList();
        public Song GetById(int id);
        public void Add(Song course);
        public void Update(int id, Song course);
        public void UpdateStatus(int id, bool status);
    }
}
