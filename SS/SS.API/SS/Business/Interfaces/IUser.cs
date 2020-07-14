using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Models.User;

namespace SS.Business.Interfaces
{
    public interface IUser
    {
        Task<IdentityResult> RegisterUserAsync(UserForRegisterDto userForRegisterDto);
        Task<UserDto> GetUserAsync(int userId);
        Task<UserDto> GetUserAsync(string userName);
    }
}