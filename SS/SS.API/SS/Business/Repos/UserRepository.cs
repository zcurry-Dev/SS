using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SS.API.Business.Dtos.Accept;
using SS.API.Business.Dtos.Return;
using SS.API.Business.Interfaces;
using SS.API.Data.Interfaces;
using SS.API.Data.Models;

namespace SS.API.Business.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDataRepository _user;
        private readonly IMapper _mapper;

        public UserRepository(IUserDataRepository user, IMapper mapper)
        {
            _mapper = mapper;
            _user = user;
        }

        public async Task<UserForDetailDto> GetUserById(int userId)
        {
            var ssUser = await _user.GetUserById(userId.ToString());

            if (ssUser == null)
            {
                throw new NullReferenceException();
            }

            var userToReturn = _mapper.Map<UserForDetailDto>(ssUser);

            if (userToReturn == null)
            {
                throw new NullReferenceException();
            }

            return userToReturn;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto)
        {
            var user = _mapper.Map<Ssuser>(userForRegisterDto);

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
            var userToReturn = _mapper.Map<UserForDetailDto>(user);
            return userToReturn;
        }
    }
}