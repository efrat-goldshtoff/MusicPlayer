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
    public class UserService:ISingerService
    {
        private readonly SongRepository _courseRepository;
        public UserService(SongRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<Singer> GetList()
        {
            return _courseRepository.GetList();
        }

        public Singer? GetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public void Add(Singer guide)
        {
            _courseRepository.Add(guide);
        }

        public void Update(int id, Singer guide)
        {
            _courseRepository.Update(id, guide);
        }

        public void UpdateStatus(int id, bool status)
        {
            _courseRepository.UpdateStatus(id, status);
        }
    }
}
