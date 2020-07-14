using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Models.User;

namespace SS.Business.Interfaces
{
    public interface IAuth
    {
        Task<SignInResult> CheckPasswordSignInAsync(UserDto user, string password);
        Task<string> GenerateJwtTokenAsync(UserDto user);
    }
}