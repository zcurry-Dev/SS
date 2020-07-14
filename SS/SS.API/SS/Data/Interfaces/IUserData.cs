
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Data.Models;

namespace SS.Data.Interfaces
{
    public interface IUserData : IDataRepo<Ssuser>
    {
        Task<IdentityResult> CreateUserAsync(Ssuser user, string password);
        Task<IdentityResult> AddUserRoleOnRegisterAsync(Ssuser user);
        Task<IdentityResult> UpdateLastActiveAsync(ClaimsPrincipal cp);
        Task<PagedListData<Ssuser>> GetUsersAsync(int pageIndex, int pageSize = 10, string search = "", string orderBy = "");
        Task<IdentityResult> AddRolesToUserAsync(Ssuser user, IEnumerable<string> roles);
        Task<IdentityResult> RemoveRolesFromUserAsync(Ssuser user, IEnumerable<string> roles);
        Task<IEnumerable<string>> GetRolesFromUserAsync(string userName);
        Task<SignInResult> CheckPasswordSignInAsync(Ssuser user, string password);
    }
}