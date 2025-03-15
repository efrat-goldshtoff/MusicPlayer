using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.models;
using Courses.Core.Repositories;
using Courses.Core.Services;

namespace Courses.Service
{
    public class SingerService : ISongtService
    {
        private readonly ISingerRepository _courseRepository;
        public SingerService(ISingerRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }



        public IEnumerable<User> GetList()
        {
            return _courseRepository.GetList();
        }

        public User GetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public void Add(User student)
        {
            _courseRepository.Add(student);
        }

        public void Update(int id, User student)
        {
            _courseRepository.Update(id, student);
        }

        public void UpdateStatus(int id, bool status)
        {
            _courseRepository.UpdateStatus(id, status);
        }
    }
}
