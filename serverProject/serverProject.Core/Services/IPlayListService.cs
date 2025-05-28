using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serverProject.Core.DTOs;
using serverProject.Core.models;

namespace serverProject.Core.Services
{
    public interface IPlayListService
    {
        Task<IEnumerable<PlayList>> GetAllAsync();
        Task<PlayList> GetByIdAsync(int id);
        Task<IEnumerable<PlayList>> GetPlaylistsByUserIdAsync(int userId);
        Task<PlayList> AddAsync(PlayListDto playlistDto);
        Task<PlayList> UpdateAsync(int id, PlayListDto playlistDto);
        Task DeleteAsync(int id);
        Task AddSongToPlaylistAsync(int playlistId, int songId);
        Task RemoveSongFromPlaylistAsync(int playlistId, int songId);
    }
}
