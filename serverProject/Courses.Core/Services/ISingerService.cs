using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.models;

namespace Courses.Core.Services
{
    public interface ISingerService
    {
        public IEnumerable<Singer> GetList();
        public Singer? GetById(int id);
        public void Add(Singer guide);
        public void Update(int id, Singer guide);
        public void UpdateStatus(int id, bool status);
    }
}
