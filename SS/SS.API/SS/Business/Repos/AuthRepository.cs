using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SS.Business.Dtos.Return;
using SS.Business.Interfaces;
using SS.Business.Mappings.Interfaces;
using SS.Data.Interfaces;

namespace SS.Business.Repos
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IAuthDataRepository _auth;
        private readonly IConfiguration _config;
        private readonly IAuthMapping _map;
        private readonly IUserDataRepository _user;

        public AuthRepository(
            IAuthDataRepository auth,
            IConfiguration config,
            IAuthMapping map,
            IUserDataRepository user
            )
        {
            _auth = auth;
            _config = config;
            _map = map;
            _user = user;
        }

        public async Task<SignInResult> CheckPasswordSignInAsync(UserForDetailDto user, string password)
        {
            var ssUser = await _user.GetUserByUserName(user.UserName);
            var result = await _auth.CheckPasswordSignInAsync(ssUser, password);
            return result;
        }

        public async Task<string> GenerateJwtToken(UserForDetailDto user)
        {
            var claims = new List<Claim> {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim (ClaimTypes.Name, user.DisplayName)
            };

            var ssUser = _map.MapToSsuser(user);
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
    }
}