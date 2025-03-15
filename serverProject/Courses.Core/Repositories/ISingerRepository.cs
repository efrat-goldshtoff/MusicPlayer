using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.models;

namespace Courses.Core.Repositories
{
    public interface ISingerRepository
    {
        public IEnumerable<User> GetList();
        public User GetById(int id);
        public User Add(User student);
        public void Update(int id, User student);
        public void UpdateStatus(int id, bool status);
    }
}
