using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class ArtistDataRepository : IArtistDataRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        public ArtistDataRepository(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<Artist> GetArtists()
        {
            var artists = _context.Artist.AsQueryable();

            return artists;
        }

        public async Task<Artist> GetArtistById(int artistId)
        {
            var artist = await _context.Artist.FirstOrDefaultAsync(a => a.ArtistId == artistId);

            return artist;
        }
    }
}