using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Courses.Core.DTOs;
using Courses.Core.models;
using Courses.Core.Repositories;
using Courses.Core.Services;

namespace Courses.Service
{
    public class SingerService : ISingerService
    {
        private readonly ISingerRepository _singerRepository;
        private readonly IMapper _mapper;

        public SingerService(ISingerRepository singerRepository, IMapper mapper)
        {
            _singerRepository = singerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Singer>> GetAllAsync()
        {
            return await _singerRepository.GetAllasync();
        }

        public async Task<Singer> GetByIdAsync(int id)
        {
            return await _singerRepository.GetByIdAsync(id);

        }


        public async Task<Singer> AddAsync(SingerDto singer)
        {
            var singerMap = _mapper.Map<Singer>(singer);
            return await _singerRepository.AddAsync(singerMap);
        }


        public async Task<Singer> UpdateAsync(int id, SingerDto singer)
        {
            var singerMap = _mapper.Map<Singer>(singer);
            return await _singerRepository.UpdateAsync(id, singerMap);
        }

        public async Task DeleteAsync(int id) =>
        await _singerRepository.DeleteAsync(id);

    }
}
