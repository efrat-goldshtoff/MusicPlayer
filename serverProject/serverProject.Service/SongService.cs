using AutoMapper;
using serverProject.Core.DTOs;
using serverProject.Core.models;
using serverProject.Core.Repositories;
using serverProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverProject.Service
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;
        private readonly IAIGenreService _aiGenreService; // Inject AI service
        public SongService(ISongRepository songRepository, IMapper mapper, IAIGenreService aIGenreService)
        {
            _songRepository = songRepository;
            _mapper = mapper;
            _aiGenreService = aIGenreService;
        }
        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _songRepository.GetAllasync();
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            return await _songRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Song>> SearchSongsByAIAsync(string query)
        {
            // First, get genres from AI based on the query
            var identifiedGenres = await _aiGenreService.GetGenresFromTextAsync(query);

            if (identifiedGenres.Any())
            {
                // Then, filter songs by these genres from your repository
                var allSongs = await _songRepository.GetAllasync(); // Or a more specific method
                return allSongs.Where(s => identifiedGenres.Contains(s.Genre.ToLower())).ToList();
            }
            else
            {
                // If AI couldn't identify genres, perhaps search by song name or return all
                return await _songRepository.GetAllasync(); // Fallback
            }
        }

        public async Task<Song> AddAsync(SongDto song)
        {
            var songMap = _mapper.Map<Song>(song);
            return await _songRepository.AddAsync(songMap);
        }

        public async Task<Song> UpdateAsync(int id, SongDto song)
        {
            var songMap = _mapper.Map<Song>(song);
            return await _songRepository.UpdateAsync(id, songMap);
        }

        public async Task DeleteAsync(int id) =>
            await (_songRepository.DeleteAsync(id));

        public async Task<IEnumerable<Song>> GetSongsByGenreAsync(string genre)
        {
            return await _songRepository.GetSongByGenreAsync(genre);
        }
    }
}
