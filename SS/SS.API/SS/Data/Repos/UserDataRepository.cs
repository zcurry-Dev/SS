using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SS.API.Data.Interfaces;
using SS.API.Data.Models;

namespace SS.API.Data.Repos
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<Ssuser> _userManager;
        public UserDataRepository(
            DataContext context,
            IMapper mapper,
            UserManager<Ssuser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Ssuser> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        public async Task<IdentityResult> UpdateLastActiveForUser(ClaimsPrincipal cp)
        {
            var user = await _userManager.GetUserAsync(cp);
            user.LastActive = DateTime.Now;

            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> CreateUser(Ssuser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<IdentityResult> AddUserRole(Ssuser user)
        {
            var result = await _userManager.AddToRoleAsync(user, "User");
            return result;
        }

        public async Task<Ssuser> GetUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<IList<string>> GetRolesForUser(Ssuser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }

        public async Task<IList<string>> GetRolesForUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }
    }
}