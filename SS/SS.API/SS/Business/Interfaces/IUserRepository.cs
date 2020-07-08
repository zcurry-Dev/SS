using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Models.User;

namespace SS.Business.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto);
        Task<UserDto> GetUserById(int userId);
        Task<UserDto> GetUserForDetailToReturn(string userName);
    }
}