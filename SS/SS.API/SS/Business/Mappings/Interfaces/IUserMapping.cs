using SS.Business.Models.User;
using SS.Data.Models;

namespace SS.Business.Mappings.Interfaces
{
    public interface IUserMapping
    {
        UserForDetailDto MapToUserForDetailDto(Ssuser Ssuser);
        Ssuser MapToSsuser(UserForRegisterDto user);
    }
}