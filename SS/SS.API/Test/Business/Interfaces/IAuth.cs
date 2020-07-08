using System.Threading.Tasks;
using SS.Business.Models.User;

namespace Test.Business.Interfaces
{
    public interface IAuth
    {
        Task RegisterUser(UserForRegisterDto toRegister);
        Task GetUserForDetailToReturn(string userName);
        Task GenerateJwtToken(UserDto user);
        Task CheckPasswordSignIn(UserDto user, string password);
    }
}