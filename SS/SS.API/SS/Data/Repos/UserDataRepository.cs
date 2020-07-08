using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class UserDataRepository : DataRepository<Ssuser>, IUserDataRepository
    {
        private readonly SignInManager<Ssuser> _signInManager;
        private readonly UserManager<Ssuser> _userManager;
        public UserDataRepository(DataContext context, UserManager<Ssuser> userManager, SignInManager<Ssuser> signInManager) : base(context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUser(Ssuser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<IdentityResult> AddUserRoleOnRegister(Ssuser user)
        {
            var result = await _userManager.AddToRoleAsync(user, "User");
            return result;
        }

        public async Task<IdentityResult> UpdateLastActiveForUser(ClaimsPrincipal cp)
        {
            var user = await _userManager.GetUserAsync(cp);
            user.LastActive = DateTime.Now;

            return await _userManager.UpdateAsync(user);
        }

        public async Task<IEnumerable<string>> GetRolesForUser(Ssuser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }

        public async Task<IEnumerable<string>> GetRolesForUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }

        public async Task<IdentityResult> AddRolesToUser(Ssuser user, IEnumerable<string> roles)
        {
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }

        public async Task<IdentityResult> RemoveRolesFromUser(Ssuser user, IEnumerable<string> roles)
        {
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            return result;
        }

        public async Task<IEnumerable<Ssuser>> GetUsersForList(int pageIndex, int pageSize = 10, string search = "", string orderBy = "")
        {
            var users = _userManager.Users
                    .Where(s => s.UserName.Contains(search));

            if (orderBy == "")
            {
                users.OrderByDescending(u => u.UserId);
            }
            else
            {
                users.OrderByDescending(u => u.UserName);
            }

            await users.Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            return users;
        }

        public async Task<SignInResult> CheckPasswordSignIn(Ssuser user, string password)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return result;
        }

        public Expression<Func<Ssuser, bool>> GetUserByUserName(string userName)
        {
            return u => u.UserName == userName;
        }
    }
}