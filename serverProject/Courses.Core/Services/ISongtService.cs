using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.DTOs;
using Courses.Core.models;

namespace Courses.Core.Services
{
    public interface ISongtService
    {
        public Task<IEnumerable<Song>> GetAllAsync();
        public Task<Song> GetByIdAsync(int id);
        public Task<Song> AddAsync(SongDto song);
        public Task<Song> UpdateAsync(int id, SongDto song);
        public Task DeleteAsync(int id);
    }
}
