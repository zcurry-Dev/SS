using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Business.Interfaces;
using SS.Business.Mappings.Interfaces;
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

        public async Task<UserForDetailDto> GetUserById(int userId)
        {
            var ssUser = await _user.GetUserById(userId.ToString());

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

            if (user == null)
            {
                throw new NullReferenceException();
            }

            user.UserStatusId = 1;

            var result = await _user.CreateUser(user, userForRegisterDto.Password);

            if (!result.Succeeded)
            {
                return result;
            }

            result = await _user.AddUserRoleOnRegister(user);

            return result;
        }

        public async Task<UserForDetailDto> GetUserForDetailToReturn(string userName)
        {
            var user = await _user.GetUserByUserName(userName);
            var userToReturn = _map.MapToUserForDetailDto(user);
            return userToReturn;
        }
    }
}