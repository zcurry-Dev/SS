using System.Collections.Generic;
using System.Threading.Tasks;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class UserRoleDataRepository : DataRepository<Ssrole>, IUserRoleDataRepository
    {
        public UserRoleDataRepository(DataContext context) : base(context) { }
    }
}