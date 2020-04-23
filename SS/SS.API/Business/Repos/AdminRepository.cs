using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SS.API.Business.Interfaces;
using SS.API.Data.Interfaces;
using SS.API.Dtos;
using SS.API.Helpers.Pagination;
using SS.API.Helpers.Pagination.PagedParams;
using SS.API.Models;
using SS.API.Business.Models;

namespace SS.API.Business.Repos
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IAdminDataRepository _admin;

        public AdminRepository(IAdminDataRepository admin)
        {
            _admin = admin;
        }

        public AdminRepository() { }

        public async Task<PagedList<UsersWithRoles>> GetUsersWithRoles(AdminUsersParams adminUsersParams)
        {
            var users = await _admin.GetUsersWithRoles(adminUsersParams);

            return users;
        }

        public async Task<List<Role>> GetRoles()
        {
            var roles = await _admin.GetRoles();
            var rolesToReturn = roles.Select(x => new Role
            {
                Id = x.Id,
                Name = x.Name
            }
            ).ToList();

            return rolesToReturn;
        }
    }
}