using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Models.User;

namespace SS.Business.Interfaces
{
    public interface IAuthRepository
    {
        Task<SignInResult> CheckPasswordSignIn(UserDto user, string password);
        Task<string> GenerateJwtToken(UserDto user);
    }
}