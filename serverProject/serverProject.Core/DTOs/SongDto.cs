﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serverProject.Core.models;

namespace serverProject.Core.DTOs
{
    public class SongDto
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Link { get; set; }
        public int SingerId { get; set; }
    }
}
