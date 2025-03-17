using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.DTOs;
using Courses.Core.models;

namespace Courses.Core.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllAsync();
        public Task<User> GetByIdAsync(int id);
        public Task<User> AddAsync(UserDto user);
        public Task<User> UpdateAsync(int id, UserDto user);
        public Task DeleteAsync(int id);
    }
}
