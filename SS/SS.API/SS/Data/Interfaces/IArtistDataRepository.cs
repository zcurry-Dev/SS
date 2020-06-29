using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SS.Data.Models;

namespace SS.Data.Interfaces
{
    public interface IArtistDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        IQueryable<Artist> GetArtists();
        Task<Artist> GetArtistById(int artistId);
    }
}