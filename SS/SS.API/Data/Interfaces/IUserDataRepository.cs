
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SS.API.Dtos;
using SS.API.Models;

namespace SS.API.Data.Interfaces
{
    public interface IUserDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<Ssuser> GetUser(int userId);
    }
}