using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Interfaces;
using SS.Business.Mappings;
using SS.Business.Models.User;
using SS.Data.Interfaces;

namespace SS.Business.Repos
{
    public class UserRepo : IUser
    {
        private readonly IUserData _user;
        private readonly IMap _map;

        public UserRepo(IUserData user, IMap map)
        {
            _user = user;
            _map = map;
        }

        public async Task<UserDto> GetUserAsync(int userId)
        {
            var ssUser = await _user.GetByIdAsync(userId);
            var userToReturn = _map.MapToUserForDetailDto(ssUser);
            return userToReturn;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserForRegisterDto userForRegisterDto)
        {
            var user = _map.MapToSsuser(userForRegisterDto);
            user.UserStatusId = 1;
            var result = await _user.CreateUserAsync(user, userForRegisterDto.Password);
            if (!result.Succeeded) { return result; }
            result = await _user.AddUserRoleOnRegisterAsync(user);

            return result;
        }

        public async Task<UserDto> GetUserAsync(string userName)
        {
            var user = await _user.FindAsync(u => u.UserName == userName);
            var userToReturn = _map.MapToUserForDetailDto(user);
            return userToReturn;
        }
    }
}