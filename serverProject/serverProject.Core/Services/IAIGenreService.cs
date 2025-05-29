using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverProject.Core.Services
{
    public interface IAIGenreService
    {
        Task<List<string>> GetGenresFromTextAsync(string text);
    }
}
