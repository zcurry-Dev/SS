using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SS.API.Data.Interfaces;
using SS.API.Business.Models;
using SS.API.Helpers.Pagination;
using SS.API.Helpers.Pagination.PagedParams;
using SS.API.Models;

namespace SS.API.Data.Repos
{
    public class AdminDataRepository : IAdminDataRepository
    {
        private readonly DataContext _context;
        private readonly RoleManager<Ssrole> _roleManager;
        public AdminDataRepository(DataContext context, RoleManager<Ssrole> roleManager)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public Task<PagedList<UsersWithRoles>> GetUsersWithRoles(AdminUsersParams adminUsersParams)
        {
            var users = _context.Ssuser
                .Select(user => new UsersWithRoles
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = (from userRole in user.SsuserRole
                             join role in _context.Roles
                             on userRole.RoleId
                             equals role.Id
                             select role.Name).ToList()
                }).AsQueryable();

            if (!string.IsNullOrEmpty(adminUsersParams.OrderBy))
            {
                switch (adminUsersParams.OrderBy)
                {
                    case "UserName":
                        users = users.OrderByDescending(a => a.UserName);
                        break;
                    default:
                        users = users.OrderByDescending(a => a.Id);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(adminUsersParams.Search))
            {
                users = users.Where(s => s.UserName.Contains(adminUsersParams.Search));
            }

            var p = PagedList<UsersWithRoles>.CreateAsync(users, adminUsersParams.PN, adminUsersParams.PS);


            return p;
        }

        public async Task<List<Ssrole>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return roles;
        }
    }
}