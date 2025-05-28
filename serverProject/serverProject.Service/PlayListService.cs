using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using serverProject.Core.DTOs;
using serverProject.Core.models;
using serverProject.Core.Repositories;
using serverProject.Core.Services;

namespace serverProject.Service
{
    public class PlayListService : IPlayListService
    {
        private readonly IPlayListRepository _playlistRepository;
        private readonly IMapper _mapper;

        public PlayListService(IPlayListRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayList>> GetAllAsync()
        {
            return await _playlistRepository.GetAllAsync();
        }

        public async Task<PlayList> GetByIdAsync(int id)
        {
            return await _playlistRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PlayList>> GetPlaylistsByUserIdAsync(int userId)
        {
            return await _playlistRepository.GetPlaylistsByUserIdAsync(userId);
        }

        public async Task<PlayList> AddAsync(PlayListDto playlistDto)
        {
            var playlist = _mapper.Map<PlayList>(playlistDto);
            return await _playlistRepository.AddAsync(playlist);
        }

        public async Task<PlayList> UpdateAsync(int id, PlayListDto playlistDto)
        {
            var playlist = _mapper.Map<PlayList>(playlistDto);
            return await _playlistRepository.UpdateAsync(id, playlist);
        }

        public async Task DeleteAsync(int id)
        {
            await _playlistRepository.DeleteAsync(id);
        }

        public async Task AddSongToPlaylistAsync(int playlistId, int songId)
        {
            await _playlistRepository.AddSongToPlaylistAsync(playlistId, songId);
        }

        public async Task RemoveSongFromPlaylistAsync(int playlistId, int songId)
        {
            await _playlistRepository.RemoveSongFromPlaylistAsync(playlistId, songId);
        }
    }
}
