using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serverProject.Core.models;
using serverProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace serverProject.Data.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly DataContext _context;

        public SongRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Song>> GetAllasync()
        {
            return await _context.Songs.Include(s => s.Singer).Include(s => s.users).Include(s => s.PlayLists).ToListAsync();
            //return await _context.songs.Include(s => s.Singer).Include(s => s.users).ToListAsync();
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            return await _context.Songs.Include(s => s.Singer).Include(s => s.users).Include(s => s.PlayLists).FirstOrDefaultAsync(s => s.Id == id);
            //return await _context.songs.FindAsync(id);
        }

        public async Task<IEnumerable<Song>> GetSongByGenreAsync(string g)
        {
            return await _context.Songs.Where(s => s.Genre == g).ToListAsync();
        }

        public async Task<Song> AddAsync(Song song)
        {
            await _context.Songs.AddAsync(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<Song> UpdateAsync(int id, Song song)
        {
            Song s = await _context.Songs.SingleOrDefaultAsync(a => a.Id == id);
            if (s == null)
                return null;
            else
            {
                s.Name = song.Name;
                s.Genre = song.Genre;
                s.Duration = song.Duration;
                s.Link = song.Link;
                s.ReleaseDate = song.ReleaseDate;
                s.Singer = song.Singer;
                s.SingerId = song.SingerId;
                s.users = song.users;
            }
            await _context.SaveChangesAsync();
            return s;
        }

        public async Task DeleteAsync(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
            }
        }
    }
}
