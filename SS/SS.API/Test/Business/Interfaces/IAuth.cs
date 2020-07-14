using System.Threading.Tasks;
using SS.Business.Models.User;

namespace Test.Business.Interfaces
{
    public interface IAuthTest
    {
        Task GenerateJwtToken(UserDto user);
        Task CheckPasswordSignIn(UserDto user, string password);
    }
}