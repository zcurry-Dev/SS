using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.API.Business.Dtos.Return;

namespace SS.API.Business.Interfaces
{
    public interface IAuthRepository
    {
        Task<SignInResult> CheckPasswordSignInAsync(UserForDetailDto user, string password);
        Task<string> GenerateJwtToken(UserForDetailDto user);
    }
}