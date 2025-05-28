using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serverProject.Core.models;

namespace serverProject.Core.Repositories
{
    public interface ISongRepository
    {
        public Task<IEnumerable<Song>> GetAllasync();
        public Task<Song> GetByIdAsync(int id);
        public Task<Song> AddAsync(Song song);
        public Task<Song> UpdateAsync(int id, Song song);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Song>> GetSongByGenreAsync(string genre);
    }
}
