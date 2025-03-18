using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serverProject.Core.DTOs;
using serverProject.Core.models;

namespace serverProject.Core.Services
{
    public interface ISongService
    {
        public Task<IEnumerable<Song>> GetAllAsync();
        public Task<Song> GetByIdAsync(int id);
        public Task<Song> AddAsync(SongDto song);
        public Task<Song> UpdateAsync(int id, SongDto song);
        public Task DeleteAsync(int id);
    }
}
