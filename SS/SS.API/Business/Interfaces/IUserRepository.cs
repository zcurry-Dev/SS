using System.Threading.Tasks;
using SS.API.Business.Dtos.User;

namespace SS.API.Business.Interfaces
{
    public interface IUserRepository
    {
        Task<UserForDetailDto> GetUser(int userId);
    }
}