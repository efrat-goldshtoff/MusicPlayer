using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.models;

namespace Courses.Core.Repositories
{
    public interface SongRepository
    {
        public IEnumerable<Singer> GetList();
        public Singer GetById(int id);
        public Singer Add(Singer guide);
        public void Update(int id, Singer guide);
        public void UpdateStatus(int id, bool status);
    }
}
