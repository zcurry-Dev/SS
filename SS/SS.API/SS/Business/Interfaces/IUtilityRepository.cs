using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;

namespace SS.Business.Interfaces
{
    public interface IUtilityRepository
    {
        Task<CountriesToReturnDto> GetCountries();
        Task<UsStatesToReturnDto> GetUsStates();
    }
}