using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.API.Business.Models;
using SS.API.Dtos.User;
using SS.API.Models;

namespace SS.API.Business.Interfaces
{
    public interface IAuthRepository
    {
        Task<SignInResult> CheckPasswordSignInAsync(UserDto user, string password);
        Task<string> GenerateJwtToken(UserDto user);
        Task<UserDto> GetUser(string userName);
        Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto);
        UserForDetailDto MapUserToUserForDetailDto(UserDto user);
    }
}