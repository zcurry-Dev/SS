using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class AuthDataRepository : IAuthDataRepository
    {
        private readonly SignInManager<Ssuser> _signInManager;
        public AuthDataRepository(SignInManager<Ssuser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> CheckPasswordSignInAsync(Ssuser user, string password)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return result;
        }
    }
}