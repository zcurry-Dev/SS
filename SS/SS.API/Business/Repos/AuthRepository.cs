using System.Collections.Generic;
using System.Threading.Tasks;
using SS.API.Data.Interfaces;
using SS.API.Business.Models;
using SS.API.Business.Interfaces;
using SS.API.Models;
using AutoMapper;
using SS.API.Dtos.User;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace SS.API.Business.Repos
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IAuthDataRepository _auth;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUserDataRepository _user;

        public AuthRepository(
            IAuthDataRepository auth,
            IConfiguration config,
            IMapper mapper,
            IUserDataRepository user
            )
        {
            _config = config;
            _auth = auth;
            _mapper = mapper;
            _user = user;
        }

        public async Task<SignInResult> CheckPasswordSignInAsync(User user, string password)
        {
            var ssuser = _mapper.Map<Ssuser>(user);
            var result = await _auth.CheckPasswordSignInAsync(ssuser, password);
            return result;
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim> {
                new Claim (ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim (ClaimTypes.Name, user.DisplayName)
            };

            var ssUser = _mapper.Map<Ssuser>(user);
            var roles = await _user.GetRolesForUser(ssUser);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<User> GetUser(string userName)
        {
            var user = await _user.GetUserByUserName(userName);
            var userToReturn = _mapper.Map<User>(user);
            return userToReturn;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto)
        {
            var user = _mapper.Map<Ssuser>(userForRegisterDto);
            user.UserStatusId = 1;
            var result = await _user.CreateUser(user, userForRegisterDto.Password);

            if (!result.Succeeded)
            {
                return result;
            }

            result = await _user.AddRoleUserRole(user);

            return result;
        }

        public UserForDetailDto MapUserToUserForDetailDto(User user)
        {
            var appUser = _mapper.Map<UserForDetailDto>(user);
            return appUser;
        }
    }
}