using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Core.DTOs;
using Courses.Core.models;

namespace Courses.Core
{
    public class Mapping
    {
        public SongDto MapToSongDto(Song value)
        {
            return new SongDto
            {
                Id = value.Id,
                Subject = value.Subject,
                CurrentCount = value.CurrentCount,
                MaxCount = value.MaxCount,
                GuideId = value.GuideId,
                Day = value.Day
            };
        }
        public SingerDto MapToSingerDto(Singer value)
        {
            return new SingerDto
            {
                Id = value.Id,
                Name = value.Name,
                IsActive = value.IsActive
            };
        }
        public UserDto MapToUserDto(User value)
        {
            return new UserDto
            {
                Id = value.Id,
                Name = value.Name,
                IsActive = value.IsActive
            };
        }

    }
}
