using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SS.API.Dtos;
using SS.API.Helpers.Pagination;
using SS.API.Helpers.Pagination.PagedParams;
using SS.API.Models;

namespace SS.API.Data.Interfaces
{
    public interface IArtistRepository
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