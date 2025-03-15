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
    public class SingerRepository : ISingerRepository
    {
        private readonly DataContext _context;
        public SingerRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetList()
        {
            return _context.students.Include(s => s.Courses);
        }

        public User GetById(int id)
        {
            return _context.students.First(s => s.Id == id);
        }

        public User Add(User stud)
        {
            _context.students.Add(stud);
            _context.SaveChanges();
            return stud;
        }

        public void Update(int id, User stud)
        {
            User s = GetById(id);
            if (s == null)
                return;
            else
            {
                s.Name = stud.Name;
                s.IsActive = stud.IsActive;
                s.Courses = new List<Song>();
                foreach (Song course in stud.Courses)
                {
                    s.Courses.Add(course);
                }
            }
            _context.SaveChanges();
        }

        public void UpdateStatus(int id, bool status)
        {
            User s = GetById(id);
            if (s != null)
                s.IsActive = status;
            _context.SaveChanges();
        }

    }
}
