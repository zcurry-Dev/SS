using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.API.Data.Models;

namespace SS.API.Data.Interfaces
{
    public interface IAdminDataRepository
    {
        Task<List<Ssuser>> GetAllUsers();
        Task<List<Ssrole>> GetAllAvailibleRoles();
        Task<IdentityResult> AddRolesToUser(Ssuser user, string[] selectedRoles, IList<string> userRoles);
        Task<IdentityResult> RemoveRolesFromUser(Ssuser user, IList<string> userRoles, string[] selectedRoles);
    }
}