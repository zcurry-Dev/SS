using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Identity;
using Moq;
using SS.Business.Interfaces;
using SS.Business.Mappings;
using SS.Business.Models.User;
using SS.Business.Repos;
using SS.Data.Interfaces;
using SS.Data.Models;
using Test.Business.ClassData;
using Test.Business.Interfaces;
using Xunit;

namespace Test.Business.Repos
{
    public class UserTest : IUserTest
    {
        [Theory]
        [InlineData(1)]
        public async Task GetUserAsyncById(int userId)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var user = new Ssuser { Id = userId };
                var userDto = new UserDto { Id = userId };

                mock.Mock<IUserData>().Setup(x => x.GetByIdAsync(userId)).Returns(Task.FromResult(user));
                mock.Mock<IMap>().Setup(x => x.MapToUserForDetailDto(user)).Returns(userDto);

                var cls = mock.Create<UserRepo>();
                var expected = new UserDto { Id = userId };
                var actual = await cls.GetUserAsync(userId);

                Assert.True(actual != null);
                Assert.Equal(expected.Id, actual.Id);
            }
        }

        [Theory]
        [InlineData("myUserName")]
        [InlineData("test Name")]
        public async Task GetUserAsyncByUserName(string userName)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var user = new Ssuser { UserName = userName };
                var userDto = new UserDto { UserName = userName };

                // Expression<Func<Ssuser, bool>> ex = u => u.UserName == userName;
                // // would like to test with ^^this^^ but don't think I'm able to
                // mock.Mock<IUserDataRepository>().Setup(x => x.Find(ex)).Returns(Task.FromResult(user));

                mock.Mock<IUserData>().Setup(x => x.FindAsync(It.IsAny<Expression<Func<Ssuser, bool>>>()))
                    .Returns(Task.FromResult(user));
                mock.Mock<IMap>().Setup(x => x.MapToUserForDetailDto(user)).Returns(userDto);

                var cls = mock.Create<UserRepo>();
                var expected = new UserDto { UserName = userName };
                var actual = await cls.GetUserAsync(userName);

                Assert.True(actual != null);
                Assert.Equal(expected.UserName, actual.UserName);
            }
        }

        [Theory]
        [ClassData(typeof(UserForRegisterData))]
        public async Task RegisterUser(UserForRegisterDto toRegister)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var user = new Ssuser()
                {
                    FirstName = toRegister.FirstName,
                    LastName = toRegister.LastName,
                    Email = toRegister.Email,
                    UserName = toRegister.UserName,
                };
                var ir = IdentityResult.Success;

                mock.Mock<IMap>().Setup(x => x.MapToSsuser(toRegister)).Returns(user);
                mock.Mock<IUserData>().Setup(x => x.CreateUserAsync(user, toRegister.Password))
                    .Returns(Task.FromResult(ir));
                mock.Mock<IUserData>().Setup(x => x.AddUserRoleOnRegisterAsync(user))
                    .Returns(Task.FromResult(ir));

                var cls = mock.Create<UserRepo>();
                var expected = IdentityResult.Success;
                var actual = await cls.RegisterUserAsync(toRegister);

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
                Assert.Equal(expected, actual);
            }
        }
    }
}