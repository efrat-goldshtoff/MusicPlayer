using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serverProject.Core.models;
using serverProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace serverProject.Data.Repositories
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
            return await _context.Users.Include(u => u.songs).Include(u => u.PlayLists).ToListAsync();
            //return await _context.users.Include(u => u.songs).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Include(u => u.songs).Include(u => u.PlayLists).FirstOrDefaultAsync(u => u.Id == id);
            //return await _context.users.FindAsync(id);
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<User> GEtByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            User u = await _context.Users.SingleOrDefaultAsync(a => a.Id == id);
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

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public User GetUserByCredentials(string name, string password)
        {
            return _context.Users.FirstOrDefault(user => user.Name == name && user.Password == password);
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
