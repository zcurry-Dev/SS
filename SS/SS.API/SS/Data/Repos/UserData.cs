using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Identity;
using SS.Business.Pagination;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class UserData : DataRepo<Ssuser>, IUserData
    {
        private readonly SignInManager<Ssuser> _signInManager;
        private readonly UserManager<Ssuser> _userManager;
        public UserData(
            DataContext context,
            UserManager<Ssuser> userManager,
            SignInManager<Ssuser> signInManager)
                : base(context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(Ssuser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<IdentityResult> AddUserRoleOnRegisterAsync(Ssuser user)
        {
            var result = await _userManager.AddToRoleAsync(user, "User");
            return result;
        }

        public async Task<IdentityResult> UpdateLastActiveAsync(ClaimsPrincipal cp)
        {
            var user = await _userManager.GetUserAsync(cp);
            user.LastActive = DateTime.Now;

            return await _userManager.UpdateAsync(user);
        }

        public async Task<IEnumerable<string>> GetRolesFromUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }

        public async Task<IdentityResult> AddRolesToUserAsync(Ssuser user, IEnumerable<string> roles)
        {
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }

        public async Task<IdentityResult> RemoveRolesFromUserAsync(Ssuser user, IEnumerable<string> roles)
        {
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            return result;
        }

        public async Task<PagedListData<Ssuser>> GetUsersAsync(int pageIndex, int pageSize = 10, string search = "", string orderBy = "")
        {
            if (!search.IsNullOrEmpty())
            {
                _userManager.Users.Where(s => s.UserName.Contains(search));  //todo more searching fields
            }

            if (orderBy.IsNullOrEmpty())
            {
                _userManager.Users.OrderByDescending(u => u.LastName); //todo
            }
            else
            {
                _userManager.Users.OrderByDescending(u => u.Id); //todo
            }

            var pagedList = await PagedListData<Ssuser>.CreateAsync(_userManager.Users, pageIndex, pageSize);

            return pagedList;
        }

        public async Task<SignInResult> CheckPasswordSignInAsync(Ssuser user, string password)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return result;
        }
    }
}