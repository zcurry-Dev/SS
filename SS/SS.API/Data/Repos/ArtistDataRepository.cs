using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SS.API.Business.Dtos.Photo;
using SS.API.Data.Interfaces;
using SS.API.Data.Models;
using SS.API.Helpers.Pagination;
using SS.API.Helpers.Pagination.PagedParams;

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

        public async Task<Artist> GetArtist(int artistId)
        {
            var artist = await _context.Artist.FirstOrDefaultAsync(a => a.ArtistId == artistId);

            return artist;
        }

        public async Task<PagedList<Artist>> GetArtists(ArtistParams artistParams)
        {
            var artists = _context.Artist.OrderByDescending(a => a.CareerBeginDate).AsQueryable();

            if (!string.IsNullOrEmpty(artistParams.OrderBy))
            {
                switch (artistParams.OrderBy)
                {
                    case "created":
                        artists = artists.OrderByDescending(a => a.CreatedDate);
                        break;
                    default:
                        artists = artists.OrderByDescending(a => a.CareerBeginDate);
                        break;
                }
            }

            return await PagedList<Artist>.CreateAsync(artists,
                artistParams.PN, artistParams.PS);
        }

        public async Task<ArtistPhoto> GetArtistPhoto(int artistPhotoId)
        {
            return await _context.ArtistPhoto
                .FirstOrDefaultAsync(p => p.ArtistPhotoId == artistPhotoId);
        }

        public async Task<Byte[]> GetPhotoFile(int artistPhotoId)
        {
            var rootPath = _config.GetValue<string>("UploadedFiles:Images:Artists");
            var photo = await _context.ArtistPhoto.Where(p => p.ArtistPhotoId == artistPhotoId)
                .FirstOrDefaultAsync();
            var fullPath = rootPath + photo.ArtistId + "/" + photo.PhotoFileName;

            return await System.IO.File.ReadAllBytesAsync(fullPath);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ArtistPhoto> UploadPhoto(int artistId, PhotoForCreationDto photoForCreationDto)
        {
            var artistFromRepo = await this.GetArtist(artistId);
            var rootPath = _config.GetValue<string>("UploadedFiles:RootPath");
            string pathForArtist = rootPath + "images/artists/" + artistFromRepo.ArtistId + "/";

            if (!Directory.Exists(pathForArtist))
            {
                Directory.CreateDirectory(pathForArtist);
            }

            pathForArtist += photoForCreationDto.File.FileName;

            using (var stream = new FileStream(pathForArtist, FileMode.Create))
            {
                await photoForCreationDto.File.CopyToAsync(stream);
            }

            var photo = _mapper.Map<ArtistPhoto>(photoForCreationDto);
            photo.PhotoPath = pathForArtist;
            photo.PhotoFileExt = Path.GetExtension(photoForCreationDto.File.FileName);
            photo.PhotoFileContentType = photoForCreationDto.File.ContentType;

            if (!artistFromRepo.ArtistPhoto.Any(a => a.IsMain))
            {
                photo.IsMain = true;
            }

            // TODO
            if (photo.PhotoDescription == null)
            {
                photo.PhotoDescription = photoForCreationDto.File.FileName;
            }

            artistFromRepo.ArtistPhoto.Add(photo);

            return photo;
        }

        public async Task<ArtistPhoto> GetMainPhotoForArtist(int artistId)
        {
            return await _context.ArtistPhoto.Where(p => p.ArtistId == artistId)
                .FirstOrDefaultAsync(p => p.IsMain);
        }
    }
}