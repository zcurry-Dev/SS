using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SS.API.Data.Interfaces;
using SS.API.Data.Models;

namespace SS.API.Data.Repos
{
    public class ArtistDataRepository : IArtistDataRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public ArtistDataRepository(DataContext context, IConfiguration config, IMapper mapper)
        {
            _context = context;
            _config = config;
            _mapper = mapper;
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

        public async Task<Artist> GetArtistById(int artistId)
        {
            var artist = await _context.Artist.FirstOrDefaultAsync(a => a.ArtistId == artistId);

            return artist;
        }

        public async Task<List<Artist>> GetArtists()
        {
            var artists = await _context.Artist.ToListAsync();

            return artists;
        }

        public async Task<ArtistPhoto> GetArtistPhotoByPhotoId(int artistPhotoId)
        {
            var artistPhoto = await _context.ArtistPhoto.FirstOrDefaultAsync(p => p.ArtistPhotoId == artistPhotoId);

            return artistPhoto;
        }

        public async Task<Byte[]> GetArtistPhotoFile(int artistPhotoId)
        {
            var rootPath = _config.GetValue<string>("UploadedFiles:Images:Artists");
            var photo = await _context.ArtistPhoto.Where(p => p.ArtistPhotoId == artistPhotoId)
                .FirstOrDefaultAsync();
            var fullPath = rootPath + photo.ArtistId + "/" + photo.PhotoFileName;

            return await System.IO.File.ReadAllBytesAsync(fullPath);
        }

        public async Task<bool> UploadArtistPhoto(int artistId, ArtistPhoto artistPhoto, IFormFile file)
        {
            var artistFromRepo = await this.GetArtistById(artistId);
            var rootPath = _config.GetValue<string>("UploadedFiles:RootPath");
            string pathForArtist = rootPath + "images/artists/" + artistPhoto.ArtistId + "/";

            if (!Directory.Exists(pathForArtist))
            {
                Directory.CreateDirectory(pathForArtist);
            }

            pathForArtist += file.FileName;

            using (var stream = new FileStream(pathForArtist, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            artistPhoto.PhotoPath = pathForArtist;
            artistPhoto.PhotoFileExt = Path.GetExtension(file.FileName);
            artistPhoto.PhotoFileContentType = file.ContentType;

            if (!artistFromRepo.ArtistPhoto.Any(a => a.IsMain))
            {
                artistPhoto.IsMain = true;
            }

            // TODO
            if (artistPhoto.PhotoDescription == null)
            {
                artistPhoto.PhotoDescription = file.FileName;
            }

            artistFromRepo.ArtistPhoto.Add(artistPhoto);

            var result = await SaveAll();

            return result;
        }

        public async Task<ArtistPhoto> GetMainArtistPhotoByArtistId(int artistId)
        {
            var artistPhoto = await _context.ArtistPhoto
                .Where(p => p.ArtistId == artistId)
                .FirstOrDefaultAsync(p => p.IsMain);

            return artistPhoto;
        }

        public async Task<ArtistPhoto> GetMostRecentArtistPhoto(int artistId)
        {
            var artistPhoto = await _context.ArtistPhoto
                .Where(p => p.ArtistId == artistId)
                .OrderByDescending(p => p.ArtistPhotoId)
                .FirstOrDefaultAsync(); // want to verify this is returning proper photo

            return artistPhoto;
        }
    }
}