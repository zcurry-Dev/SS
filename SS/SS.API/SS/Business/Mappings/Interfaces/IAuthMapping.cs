
using SS.Business.Dtos.Return;
using SS.Data.Models;

namespace SS.Business.Mappings.Interfaces
{
    public interface IAuthMapping
    {
        Ssuser MapToSsuser(UserForDetailDto user);
    }
}