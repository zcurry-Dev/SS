using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.API.Business.Dtos.Accept;
using SS.API.Business.Dtos.Return;

namespace SS.API.Business.Interfaces
{
    public interface IUserRepository
    {
        Task<UserForDetailDto> GetUserById(int userId);
        Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto);
        Task<UserForDetailDto> GetUserForDetailToReturn(string userName);
    }
}