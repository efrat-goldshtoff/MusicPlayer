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
        public SongService(ISongRepository songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _songRepository.GetAllasync();
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            return await _songRepository.GetByIdAsync(id);
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
    }
}
