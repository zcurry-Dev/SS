using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Dtos.Return;

namespace SS.Business.Interfaces
{
    public interface IAuthRepository
    {
        Task<SignInResult> CheckPasswordSignInAsync(UserForDetailDto user, string password);
        Task<string> GenerateJwtToken(UserForDetailDto user);
    }
}