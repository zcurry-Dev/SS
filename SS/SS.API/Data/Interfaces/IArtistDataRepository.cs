using System;
using System.Threading.Tasks;
using SS.API.Business.Dtos.Photo;
using SS.API.Data.Models;
using SS.API.Helpers.Pagination;
using SS.API.Helpers.Pagination.PagedParams;

namespace SS.API.Data.Interfaces
{
    public interface IArtistDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PagedList<Artist>> GetArtists(ArtistParams artistParams);
        Task<Artist> GetArtist(int artistId);
        Task<ArtistPhoto> GetArtistPhoto(int artistPhotoId);
        Task<Byte[]> GetPhotoFile(int artistPhotoId);
        Task<ArtistPhoto> UploadPhoto(int artistId, PhotoForCreationDto photoForCreationDto);
        Task<ArtistPhoto> GetMainPhotoForArtist(int artistId);
    }
}