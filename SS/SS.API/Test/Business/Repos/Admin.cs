using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.User;
using SS.Business.Pagination;
using SS.Business.Repos;
using SS.Data;
using SS.Data.Interfaces;
using SS.Data.Models;
using Test.Business.ClassData;
using Xunit;

namespace Test.Business.Repos
{
    public class Admin
    {
        // ListUsers
        [Theory]
        [ClassData(typeof(AdminUsersParamsData))]
        public async Task GetAllUsersWithRoles(AdminUsersParams p)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var users = new List<Ssuser>() {
                    new Ssuser(){
                        UserName = "First"
                    },
                    new Ssuser(){
                        UserName = "Second"
                    }
                };

                var usersWithRoles = new List<UserWithRolesDto>() {
                    new UserWithRolesDto{
                        UserName = "First"
                    },
                    new UserWithRolesDto{
                        UserName = "Second"
                    },
                };

                var pl = new PagedList<Ssuser>(users, 100, 1, 10);
                var pldto = new PagedListDto<UserWithRolesDto>
                {
                    Items = usersWithRoles,
                    CurrentPage = pl.CurrentPage,
                    TotalPages = pl.TotalPages,
                    TotalItems = pl.TotalItems,
                    ItemsPerPage = pl.ItemsPerPage
                };

                mock.Mock<IUserDataRepository>().Setup(x => x.GetUsersForList(p.PN, p.IPP, p.Search, p.OrderBy))
                    .Returns(Task.FromResult(pl));
                mock.Mock<IAdminMapping>().Setup(x => x.MapToUserWithRolesDto(pl))
                    .Returns(pldto);

                var cls = mock.Create<AdminRepository>();
                var expected = pldto;
                var actual = await cls.GetAllUsersWithRoles(p);

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
            }
        }
    }
}