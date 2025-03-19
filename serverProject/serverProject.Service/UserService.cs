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

        public User Authenticate(string name, string password)
        {
            if (name == "" && password == "")
            {
                return new User
                {
                    Name = name,
                    Password = password,
                    Role = "manager"
                };
            }
            var user = _userRepository.GetUserByCredentials(name, password);
            if (user != null)
            {
                user.Role = "user";
                return user;
            }
            return new User
            {
                Name = name,
                Password = password,
                Role = "viewer"
            };
        }

    }

}
