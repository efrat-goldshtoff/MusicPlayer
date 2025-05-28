using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverProject.Core.DTOs
{
    public class PlayListDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public List<int> SongIds { get; set; }
    }
}
