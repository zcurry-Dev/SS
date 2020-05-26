using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.API.Data.Models;

namespace SS.API.Data.Interfaces
{
    public interface IAuthDataRepository
    {
        Task<SignInResult> CheckPasswordSignInAsync(Ssuser user, string password);
    }
}