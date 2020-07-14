using System.Threading.Tasks;
using SS.Business.Pagination;

namespace Test.Business.Interfaces
{
    public interface IAdminTest
    {
        Task GetAllUsersWithRoles(AdminUsersParams p);
        Task GetAllAvailibleRoles();
        Task UpdateRolesForUser(string userName, string[] rolesToUpdate);
        Task GetRolesFromUser(string userName);
    }
}