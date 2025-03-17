using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.models;
using Courses.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Courses.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllasync()
        {
            return await _context.users.Include(u => u.songs).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.users.FindAsync(id);
        }

        public async Task<User> GEtByEmailAsync(string email)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            User u = await _context.users.SingleOrDefaultAsync(a => a.Id == id);
            if (u == null)
                return null;
            else
            {
                u.Name = user.Name;
                u.Password = user.Password;
                u.Email = user.Email;
                u.Role = user.Role;
                u.songs = user.songs;
            }
            await _context.SaveChangesAsync();
            return u;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
