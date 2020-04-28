using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SS.API.Business.Dtos.Photo;
using SS.API.Data.Models;

namespace SS.API.Data.Interfaces
{
    public interface IArtistDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<List<Artist>> GetArtists();
        Task<Artist> GetArtistById(int artistId);
        Task<ArtistPhoto> GetArtistPhotoByPhotoId(int artistPhotoId);
        Task<Byte[]> GetPhotoFile(int artistPhotoId);
        Task<ArtistPhoto> UploadPhoto(int artistId, PhotoForCreationDto photoForCreationDto);
        Task<ArtistPhoto> GetMainPhotoForArtist(int artistId);
        Task<ArtistPhoto> GetMostRecentArtistPhoto(int artistId);
    }
}