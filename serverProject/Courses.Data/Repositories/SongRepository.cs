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
    public class SongRepository : Core.Repositories.SongRepository
    {
        private readonly DataContext _context;
        public SongRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Singer> GetList()
        {
            return _context.guiders.Include(g => g.Courses);
        }

        public Singer GetById(int id)
        {
            return _context.guiders.First(g => g.Id == id);
        }

        public Singer Add(Singer guide)
        {
            _context.guiders.Add(guide);
            _context.SaveChanges();
            return guide;
        }

        public void Update(int id, Singer guide)
        {
            Singer g = GetById(id);
            if (g == null)
                return;
            else
            {
                g.Name = guide.Name;
                g.IsActive = guide.IsActive;
            }
            _context.SaveChanges();
        }

        public void UpdateStatus(int id, bool status)
        {
            Singer g = GetById(id);
            if (g != null)
                g.IsActive = status;
            _context.SaveChanges();
        }
    }
}
