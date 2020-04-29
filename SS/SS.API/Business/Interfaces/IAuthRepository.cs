using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.API.Business.Dtos.User;
using SS.API.Business.Models;

namespace SS.API.Business.Interfaces
{
    public interface IAuthRepository
    {
        Task<SignInResult> CheckPasswordSignInAsync(UserBModel user, string password);
        Task<string> GenerateJwtToken(UserBModel user);
        Task<UserBModel> GetUser(string userName);
        Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto);
        UserForDetailDto MapUserToUserForDetailDto(UserBModel user);
    }
}