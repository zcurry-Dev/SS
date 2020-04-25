using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.API.Business.Models;
using SS.API.Dtos.User;
using SS.API.Models;

namespace SS.API.Business.Interfaces
{
    public interface IAuthRepository
    {
        Task<SignInResult> CheckPasswordSignInAsync(User user, string password);
        Task<string> GenerateJwtToken(User user);
        Task<User> GetUser(string userName);
        Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto);
        UserForDetailDto MapUserToUserForDetailDto(User user);
    }
}