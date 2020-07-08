using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SS.Business.Interfaces;
using SS.Business.Models.User;
using SS.Data.Interfaces;

namespace SS.Business.Repos
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _config;
        private readonly IUserDataRepository _user;

        public AuthRepository(
            IConfiguration config,
            IUserDataRepository user
            )
        {
            _config = config;
            _user = user;
        }

        public async Task<SignInResult> CheckPasswordSignIn(UserDto dto, string password)
        {
            var user = await _user.Find(_user.GetUserByUserName(dto.UserName));
            var result = await _user.CheckPasswordSignIn(user, password);
            return result;
        }

        public async Task<string> GenerateJwtToken(UserDto user)
        {
            var claims = new List<Claim> {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim (ClaimTypes.Name, user.DisplayName)
            };

            var roles = await _user.GetRolesForUserByUserName(user.UserName);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1), // should be shortened 070820
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}