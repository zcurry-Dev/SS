using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SS.API.Data.Interfaces;
using SS.API.Business.Models;
using SS.API.Models;

namespace SS.API.Data.Repos
{
    public class AdminDataRepository : IAdminDataRepository
    {
        private readonly DataContext _context;
        private readonly RoleManager<Ssrole> _roleManager;
        private readonly UserManager<Ssuser> _userManager;
        public AdminDataRepository(
            DataContext context,
            RoleManager<Ssrole> roleManager,
            UserManager<Ssuser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<List<UsersWithRolesDto>> GetAllUsersWithRoles()
        {
            var users = await _context.Ssuser
                .Select(x => new UsersWithRolesDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Roles = x.SsuserRole.Select(r => r.Role.Name).ToList()
                }).ToListAsync();

            return users;
        }

        public async Task<List<Ssrole>> GetAllAvailibleRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return roles;
        }

        public async Task<IdentityResult> AddRolesToUser(Ssuser user, string[] selectedRoles, IList<string> userRoles)
        {
            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            return result;
        }

        public async Task<IdentityResult> RemoveRolesFromUser(Ssuser user, IList<string> userRoles, string[] selectedRoles)
        {
            var result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            return result;
        }
    }
}