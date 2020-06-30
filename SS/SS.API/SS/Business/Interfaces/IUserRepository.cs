using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Models.User;

namespace SS.Business.Interfaces
{
    public interface IUserRepository
    {
        Task<UserForDetailDto> GetUserById(int userId);
        Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto);
        Task<UserForDetailDto> GetUserForDetailToReturn(string userName);
    }
}