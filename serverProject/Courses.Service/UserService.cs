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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllasync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> AddAsync(UserDto user)
        {
            var userMap = _mapper.Map<User>(user);
            return await _userRepository.AddAsync(userMap);
        }

        public async Task<User> UpdateAsync(int id, UserDto user)
        {
            var userMap = _mapper.Map<User>(user);
            return await _userRepository.UpdateAsync(id, userMap);
        }

        public async Task DeleteAsync(int id) =>
            await _userRepository.DeleteAsync(id);

    }
}
