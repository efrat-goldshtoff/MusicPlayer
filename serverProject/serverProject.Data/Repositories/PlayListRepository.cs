using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using serverProject.Core.models;
using serverProject.Core.Repositories;

namespace serverProject.Data.Repositories
{
    public class PlayListRepository:IPlayListRepository
    {
        private readonly DataContext _context;

        public PlayListRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PlayList>> GetAllAsync()
        {
            return await _context.playLists.Include(p => p.songs).Include(p => p.User).ToListAsync();
        }

        public async Task<PlayList> GetByIdAsync(int id)
        {
            return await _context.playLists.Include(p => p.songs).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PlayList>> GetPlaylistsByUserIdAsync(int userId)
        {
            return await _context.playLists
                .Where(p => p.UserId == userId)
                .Include(p => p.songs)
                    .ThenInclude(s => s.Singer) // Include singer details for songs in playlist
                .ToListAsync();
        }

        public async Task<PlayList> AddAsync(PlayList playlist)
        {
            await _context.playLists.AddAsync(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }

        public async Task<PlayList> UpdateAsync(int id, PlayList playlist)
        {
            var existingPlaylist = await _context.playLists.FindAsync(id);
            if (existingPlaylist == null)
                return null;

            existingPlaylist.Name = playlist.Name;
            // You might want to handle song updates separately or clear and re-add them
            // For simplicity, this example only updates the name.
            // For songs, you'd need to fetch existing songs and update the collection.
            // A common approach for many-to-many is to clear existing and add new.

            await _context.SaveChangesAsync();
            return existingPlaylist;
        }

        public async Task DeleteAsync(int id)
        {
            var playlist = await _context.playLists.FindAsync(id);
            if (playlist != null)
            {
                _context.playLists.Remove(playlist);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddSongToPlaylistAsync(int playlistId, int songId)
        {
            var playlist = await _context.playLists.Include(p => p.songs).FirstOrDefaultAsync(p => p.Id == playlistId);
            var song = await _context.songs.FindAsync(songId);

            if (playlist != null && song != null && !playlist.songs.Contains(song))
            {
                playlist.songs.Add(song);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveSongFromPlaylistAsync(int playlistId, int songId)
        {
            var playlist = await _context.playLists.Include(p => p.songs).FirstOrDefaultAsync(p => p.Id == playlistId);
            var songToRemove = playlist?.songs.FirstOrDefault(s => s.Id == songId);

            if (playlist != null && songToRemove != null)
            {
                playlist.songs.Remove(songToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
