using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.DTOs;
using Courses.Core.models;

namespace Courses.Core.Services
{
    public interface ISingerService
    {
        public Task<IEnumerable<Singer>> GetAllAsync();
        public Task<Singer> GetByIdAsync(int id);
        public Task<Singer> AddAsync(SingerDto singer);
        public Task<Singer> UpdateAsync(int id, SingerDto singer);
        public Task DeleteAsync(int id);
    }
}
