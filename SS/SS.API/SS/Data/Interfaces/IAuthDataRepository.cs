using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Data.Models;

namespace SS.Data.Interfaces
{
    public interface IAuthDataRepository
    {
        Task<SignInResult> CheckPasswordSignInAsync(Ssuser user, string password);
    }
}