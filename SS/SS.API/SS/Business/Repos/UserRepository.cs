using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Interfaces;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.User;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Business.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDataRepository _user;
        private readonly IUserMapping _map;

        public UserRepository(IUserDataRepository user, IUserMapping map)
        {
            _map = map;
            _user = user;
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            var ssUser = await _user.GetById(userId);

            if (ssUser == null)
            {
                throw new NullReferenceException();
            }

            var userToReturn = _map.MapToUserForDetailDto(ssUser);

            if (userToReturn == null)
            {
                throw new NullReferenceException();
            }

            return userToReturn;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto)
        {
            var user = _map.MapToSsuser(userForRegisterDto);

            // if (user == null)
            // {
            //     throw new NullReferenceException();
            // }

            user.UserStatusId = 1;

            var result = await _user.CreateUser(user, userForRegisterDto.Password);

            if (!result.Succeeded)
            {
                return result;
            }

            result = await _user.AddUserRoleOnRegister(user);

            return result;
        }

        public async Task<UserDto> GetUserForDetailToReturn(string userName)
        {
            var user = await _user.Find(_user.GetUserByUserName(userName));
            var userToReturn = _map.MapToUserForDetailDto(user);
            return userToReturn;
        }
    }
}