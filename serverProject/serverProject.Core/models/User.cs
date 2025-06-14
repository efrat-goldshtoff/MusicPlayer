﻿namespace serverProject.Core.models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Song> songs { get; set; }
        public ICollection<PlayList> PlayLists { get; set; }
    }
}
