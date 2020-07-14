using System.Threading.Tasks;
using SS.Business.Models.User;

namespace Test.Business.Interfaces
{
    public interface IUserTest
    {
        Task RegisterUser(UserForRegisterDto userForRegisterDto);
        Task GetUserAsyncById(int userId);
        Task GetUserAsyncByUserName(string userName);
    }
}