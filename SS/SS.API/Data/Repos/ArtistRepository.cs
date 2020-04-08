using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using SS.API.Models;

namespace SS.API.Data
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        public ArtistRepository(DataContext context, IConfiguration config)
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

        public async Task<ArtistPhoto> GetArtistPhoto(int artistPhotoId)
        {
            return await _context.ArtistPhoto
                .FirstOrDefaultAsync(p => p.ArtistPhotoId == artistPhotoId);
        }

        public async Task<Byte[]> GetPhoto(int artistPhotoId)
        {
            var rootPath = _config.GetValue<string>("UploadedFiles:Images:Artists");
            var photo = await _context.ArtistPhoto.Where(p => p.ArtistPhotoId == artistPhotoId)
                .FirstOrDefaultAsync();
            var fullPath = rootPath + photo.ArtistId + "/" + photo.PhotoFileName;

            return await System.IO.File.ReadAllBytesAsync(fullPath);
        }

        public async Task<ArtistPhoto> GetPhoto2(int id)
        {
            var photo = await _context.ArtistPhoto.FirstOrDefaultAsync(p => p.ArtistId == id);

            return photo;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}