using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serverProject.Core.DTOs;
using serverProject.Core.models;

namespace serverProject.Core.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllAsync();
        public Task<User> GetByIdAsync(int id);
        public Task<User> AddAsync(UserDto user);
        public Task<User> UpdateAsync(int id, UserDto user);
        public Task DeleteAsync(int id);
        public User Authenticate(string name, string password);
    }
}
