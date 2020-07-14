using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Identity;
using Moq;
using SS.Business.Interfaces;
using SS.Business.Mappings;
using SS.Business.Models.Role;
using SS.Business.Pagination;
using SS.Business.Repos;
using SS.Data.Interfaces;
using SS.Data.Models;
using Test.Business.ClassData;
using Test.Business.Interfaces;
using Xunit;

namespace Test.Business.Repos
{
    public class AdminTest : AdminClassData, IAdminTest
    {
        [Fact]
        public async Task GetAllAvailibleRoles()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var role = new Ssrole { Name = "RoleName" };
                var roles = new List<Ssrole>();
                roles.Add(role);
                var eRoles = roles.AsEnumerable();
                var roleDto = new RoleDto { Name = "RoleName" };
                var dto = new List<RoleDto>();
                dto.Add(roleDto);

                mock.Mock<IUserRoleData>().Setup(x => x.GetAllAsync()).Returns(Task.FromResult(eRoles));
                mock.Mock<IMap>().Setup(x => x.MapToRoleDto(roles)).Returns(dto);

                var cls = mock.Create<AdminRepo>();
                var expected = dto;
                var actual = await cls.GetRolesAsync();

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
                // More Tests needed
            }
        }

        [Theory]
        [ClassData(typeof(AdminUsersParamsData))]
        public async Task GetAllUsersWithRoles(AdminUsersParams p)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var pl = CreatePagedList();
                var pldto = CreatePagedListDto();

                mock.Mock<IUserData>().Setup(x => x.GetUsersAsync(p.PN, p.IPP, p.Search, p.OrderBy))
                    .Returns(Task.FromResult(pl));
                mock.Mock<IMap>().Setup(x => x.MapToUserWithRolesDto(pl)).Returns(pldto);

                var cls = mock.Create<AdminRepo>();
                var expected = CreatePagedListDto();
                var actual = await cls.GetUsersWithRolesAsync(p);

                Assert.True(actual != null);
                Assert.Equal(expected.FirstOrDefault().UserName, // doesn't test properly
                            actual.FirstOrDefault().UserName);
                // More Tests needed
            }
        }

        [Theory]
        [InlineData("myUserName")]
        public async Task GetRolesFromUser(string userName)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var user = new Ssuser { UserName = userName };
                var roles = new List<string>{
                    "role1",
                    "role2"
                };

                // Expression<Func<Ssuser, bool>> ex = u => u.UserName == userName;
                // // would like to test with ^^this^^ but don't think I'm able to
                // mock.Mock<IUserDataRepository>().Setup(x => x.Find(ex)).Returns(Task.FromResult(user));

                mock.Mock<IUserData>().Setup(x => x.FindAsync(It.IsAny<Expression<Func<Ssuser, bool>>>()))
                    .Returns(Task.FromResult(user));

                var cls = mock.Create<AdminRepo>();
                var expected = It.IsAny<IEnumerable<string>>();
                var actual = await cls.GetRolesAsync(userName);

                Assert.True(actual != null);
                // More Tests needed
            }
        }

        [Theory]
        [InlineData("myUserName", new string[] { "a", "b", "c" })]
        public async Task UpdateRolesForUser(string userName, string[] rolesToUpdate)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var user = new Ssuser { UserName = userName };
                var ir = IdentityResult.Success;

                // Expression<Func<Ssuser, bool>> ex = u => u.UserName == userName;
                // // would like to test with ^^this^^ but don't think I'm able to
                // mock.Mock<IUserDataRepository>().Setup(x => x.Find(ex)).Returns(Task.FromResult(user));

                mock.Mock<IUserData>().Setup(x => x.FindAsync(It.IsAny<Expression<Func<Ssuser, bool>>>()))
                    .Returns(Task.FromResult(user));
                mock.Mock<IUserData>().Setup(x => x.AddRolesToUserAsync(user, rolesToUpdate)).Returns(Task.FromResult(ir));

                var cls = mock.Create<AdminRepo>();
                var expected = ir;
                var actual = await cls.UpdateRolesAsync(userName, rolesToUpdate);

                Assert.True(actual != null);
                // Assert.Equal(actual, expected);
                // More Tests needed
            }
        }
    }
}