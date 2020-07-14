using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class UserRoleData : DataRepo<Ssrole>, IUserRoleData
    {
        public UserRoleData(DataContext context) : base(context) { }
    }
}