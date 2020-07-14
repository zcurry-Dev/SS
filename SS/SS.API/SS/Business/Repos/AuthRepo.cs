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
    public class AuthRepo : IAuth
    {
        private readonly IConfiguration _config;
        private readonly IUserData _user;

        public AuthRepo(
            IConfiguration config,
            IUserData user
            )
        {
            _config = config;
            _user = user;
        }

        public async Task<SignInResult> CheckPasswordSignInAsync(UserDto dto, string password)
        {
            var user = await _user.FindAsync(u => u.UserName == dto.UserName);
            var result = await _user.CheckPasswordSignInAsync(user, password);
            return result;
        }

        public async Task<string> GenerateJwtTokenAsync(UserDto user)
        {
            var claims = new List<Claim> {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim (ClaimTypes.Name, user.DisplayName)
            };

            var roles = await _user.GetRolesFromUserAsync(user.UserName);

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