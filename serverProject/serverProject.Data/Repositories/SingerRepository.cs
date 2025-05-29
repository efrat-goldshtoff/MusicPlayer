using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using serverProject.Core.models;
using serverProject.Core.Repositories;
using serverProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace serverProject.Data.Repositories
{
    public class SingerRepository : ISingerRepository
    {
        private readonly DataContext _context;
        public SingerRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Singer>> GetAllasync()
        {
            return await _context.Singers.Include(s => s.songs).ToListAsync();
        }


        public async Task<Singer> GetByIdAsync(int id)
        {
            return await _context.Singers.FindAsync(id);
        }

        public async Task<Singer> GetByNameAsync(string name)
        {
            return await _context.Singers.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<Singer> AddAsync(Singer singer)
        {
            await _context.Singers.AddAsync(singer);
            await _context.SaveChangesAsync();
            return singer;
        }


        public async Task<Singer> UpdateAsync(int id, Singer singer)
        {
            Singer s = await _context.Singers.SingleOrDefaultAsync(a => a.Id == id);
            if (s == null)
                return null;
            else
            {
                s.Name = singer.Name;
                s.songs = singer.songs;
            }
            await _context.SaveChangesAsync();
            return s;
        }

        public async Task DeleteAsync(int id)
        {
            var singer = await _context.Singers.FindAsync(id);
            if (singer != null)
            {
                _context.Singers.Remove(singer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
