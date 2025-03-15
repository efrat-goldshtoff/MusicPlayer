using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Courses.Core.DTOs;
using Courses.Core.models;

namespace Courses.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Song,SongDto>().ReverseMap();
            CreateMap<Singer,SingerDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
        }
    }
}
