using System.Threading.Tasks;
using SS.API.Models;

namespace SS.API.Data
{
    public interface IAuthRepository
    {
        Task<Ssuser> Register(Ssuser user, string password);
        Task<Ssuser> Login(string userName, string password);
        Task<bool> UserExists(string username);
    }
}