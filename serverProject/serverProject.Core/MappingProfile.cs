﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using serverProject.Core.DTOs;
using serverProject.Core.models;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace serverProject.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Singer, SingerDto>().ReverseMap();
            CreateMap<Song, SongDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<PlayList, PlayListDto>().ReverseMap();
        }
    }
}
