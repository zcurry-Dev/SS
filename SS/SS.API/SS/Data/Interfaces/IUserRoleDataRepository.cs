using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Data.Models;

namespace SS.Data.Interfaces
{
    public interface IUserRoleDataRepository : IDataRepository<Ssrole>
    {
    }
}