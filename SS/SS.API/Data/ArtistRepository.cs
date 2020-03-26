using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SS.API.Models;

namespace SS.API.Data
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly DataContext _context;
        public ArtistRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Artist> GetArtist(int id)
        {
            var artist = await _context.Artist.Include(p => p.ArtistPhoto)
                .FirstOrDefaultAsync(u => u.ArtistId == id);

            return artist;
        }

        public async Task<IEnumerable<Artist>> GetArtists()
        {
            var artists = await _context.Artist.Include(p => p.ArtistPhoto).ToListAsync();

            return artists;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}