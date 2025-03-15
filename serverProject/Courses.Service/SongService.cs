using Courses.Core.models;
using Courses.Core.Repositories;
using Courses.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Service
{
    public class SongService : IUserService
    {
        private readonly IUserRepository _courseRepository;
        public SongService(IUserRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<Song> GetList()
        {
            return _courseRepository.GetList();
        }
        public Song GetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public void Add(Song course)
        {
            _courseRepository.Add(course);
        }

        public void Update(int id, Song course)
        {
            _courseRepository.Update(id, course);
        }

        public void UpdateStatus(int id, bool status)
        {
            _courseRepository.UpdateStatus(id, status);
        }
    }
}
