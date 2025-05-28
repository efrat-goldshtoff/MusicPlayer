using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serverProject.Core.models;

namespace serverProject.Core.Repositories
{
    public interface IPlayListRepository
    {
        Task<IEnumerable<PlayList>> GetAllAsync();
        Task<PlayList> GetByIdAsync(int id);
        Task<IEnumerable<PlayList>> GetPlaylistsByUserIdAsync(int userId);
        Task<PlayList> AddAsync(PlayList playlist);
        Task<PlayList> UpdateAsync(int id, PlayList playlist);
        Task DeleteAsync(int id);
        Task AddSongToPlaylistAsync(int playlistId, int songId);
        Task RemoveSongFromPlaylistAsync(int playlistId, int songId);
    }
}
