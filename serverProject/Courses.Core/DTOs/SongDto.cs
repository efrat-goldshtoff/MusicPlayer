using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.models;

namespace Courses.Core.DTOs
{
    public class SongDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int MaxCount { get; set; }
        public int CurrentCount { get; set; }
        public EDayOfWeek Day { get; set; }
        public bool Status { get; set; }
        public int GuideId { get; set; }
    }
}
