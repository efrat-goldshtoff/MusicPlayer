using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.models;
using Courses.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Courses.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Song> GetList()
        {
            return _context.courses.Include(c=>c.guide);
        }

        public Song GetById(int id)
        {
            return _context.courses.Include(c=>c.guide).First(c=>c.Id== id);
        }

        public Song Add(Song course)
        {
            _context.courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public void Update(int id, Song course)
        {
            Song c = GetById(id);
            if (c == null)
                return;
            else
            {
                c.Subject = course.Subject;
                c.Day = course.Day;
                c.guide = new Singer();
                c.guide.Id = course.guide.Id;
                c.guide.Name= course.guide.Name;
                c.guide.Courses = new List<Song>();
                foreach (Song item in course.guide.Courses)
                {
                    c.guide.Courses.Add(item);
                }
                c.MaxCount = course.MaxCount;
                c.CurrentCount = course.CurrentCount;
            }
            _context.SaveChanges();
        }

        public void UpdateStatus(int id, bool status)
        {
            Song c = GetById(id);
            if (c != null)
                c.Status = status;
            _context.SaveChanges();
        }
    }
}
