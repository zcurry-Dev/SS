using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Data.Models;

namespace SS.Business.Mappings.Interfaces
{
    public interface IUserMapping
    {
        UserForDetailDto MapToUserForDetailDto(Ssuser Ssuser);
        Ssuser MapToSsuser(UserForRegisterDto user);
    }
}