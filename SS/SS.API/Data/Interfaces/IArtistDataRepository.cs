using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SS.API.Data.Models;

namespace SS.API.Data.Interfaces
{
    public interface IArtistDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        IQueryable<Artist> GetArtists();
        Task<Byte[]> GetPhotoByteArray(int photoId, int artistId, string fileName);
        Task<Artist> GetArtistById(int artistId);
        Task<ArtistPhoto> GetArtistPhotoByPhotoId(int artistPhotoId);
        Task<bool> UploadArtistPhoto(int artistId, ArtistPhoto artistPhoto, IFormFile file);
        Task<ArtistPhoto> GetMainArtistPhotoByArtistId(int artistId);
        Task<ArtistPhoto> GetMostRecentArtistPhoto(int artistId);
    }
}