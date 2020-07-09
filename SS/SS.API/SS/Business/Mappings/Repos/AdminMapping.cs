using System.Collections.Generic;
using System.Linq;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Business.Pagination;
using SS.Data;
using SS.Data.Models;

namespace SS.Business.Mappings.Repos
{
    public class AdminMapping : IAdminMapping
    {
        public PagedListDto<UserWithRolesDto> MapToUserWithRolesDto(PagedList<Ssuser> pl)
        {
            var users = pl.Select(u => new UserWithRolesDto()
            {
                Id = u.Id,
                UserName = u.UserName,
                Roles = u.SsuserRole.Select(r => r.Role.ToString()).ToList(), // is this right?? 062820/070620/070920
            });

            var pldto = new PagedListDto<UserWithRolesDto>
            {
                Items = users,
                CurrentPage = pl.CurrentPage,
                TotalPages = pl.TotalPages,
                ItemsPerPage = pl.ItemsPerPage,
                TotalItems = pl.TotalItems,
            };

            return pldto;
        }

        public IEnumerable<RoleDto> MapToRoleDto(IEnumerable<Ssrole> ssroles)
        {
            var roles = ssroles.Select(r => new RoleDto()
            {
                Id = r.Id,
                Name = r.Name,
                NormalizedName = r.NormalizedName,
                ConcurrencyStamp = r.ConcurrencyStamp,
            });

            return roles;
        }
    }
}