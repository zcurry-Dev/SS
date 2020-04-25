
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.API.Models;

namespace SS.API.Data.Interfaces
{
    public interface IUserDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<Ssuser> GetUser(int userId);
        Task<IdentityResult> UpdateLastActiveForUser(ClaimsPrincipal cp);
        Task<IdentityResult> CreateUser(Ssuser user, string password);
        Task<IdentityResult> AddRoleUserRole(Ssuser user);
        Task<Ssuser> GetUserByUserName(string userName);
        Task<IList<string>> GetRolesForUser(Ssuser user);
    }
}