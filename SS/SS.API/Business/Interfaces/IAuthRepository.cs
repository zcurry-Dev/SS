using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.API.Business.Dtos.User;
using SS.API.Business.Models;

namespace SS.API.Business.Interfaces
{
    public interface IAuthRepository
    {
        Task<SignInResult> CheckPasswordSignInAsync(UserForDetailDto user, string password);
        Task<string> GenerateJwtToken(UserForDetailDto user);
        Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto);
        Task<UserForDetailDto> GetUserForDetailToReturn(string userName);
    }
}