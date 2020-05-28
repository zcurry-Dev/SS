using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;

namespace SS.Business.Interfaces
{
    public interface IUserRepository
    {
        Task<UserForDetailDto> GetUserById(int userId);
        Task<IdentityResult> RegisterUser(UserForRegisterDto userForRegisterDto);
        Task<UserForDetailDto> GetUserForDetailToReturn(string userName);
    }
}