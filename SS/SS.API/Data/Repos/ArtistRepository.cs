using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SS.API.Models;

namespace SS.API.Data
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
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

        public async Task<ArtistPhoto> GetArtistPhoto(int artistId, int photoId)
        {
            // string fullPath = @"X:/uploadedImages/artists/1/myArcher.jpg";
            // Byte[] b = System.IO.File.ReadAllBytes(fullPath);

            // var rootPath = _config.GetValue<string>("UploadedImages:Artists");

            // var photoPath = await _context.ArtistPhoto.Where(p => p.ArtistPhotoId == artistPhotoId).FirstOrDefaultAsync();
            // var fullPath = rootPath + photoPath;

            return await _context.ArtistPhoto
                .FirstOrDefaultAsync(
                    p => p.ArtistId == artistId
                    && p.ArtistId == artistId);


        }

        public async Task<Byte[]> GetPhoto(ArtistPhoto artistPhoto)
        {
            // var rootPath = _config.GetValue<string>("UploadedImages:Artists");
            // var photoPath = await _context.ArtistPhoto.Where(p => p.ArtistPhotoId == artistPhotoId).FirstOrDefaultAsync();
            // var fullPath = rootPath + photoPath;
            string fullPath = @"X:/uploadedImages/artists/1/myArcher.jpg";

            var b = await System.IO.File.ReadAllBytesAsync(fullPath);

            return b;
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