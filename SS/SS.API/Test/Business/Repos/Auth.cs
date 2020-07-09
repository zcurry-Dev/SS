using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.User;
using SS.Business.Repos;
using SS.Data.Interfaces;
using SS.Data.Models;
using Test.Business.ClassData;
using Test.Business.Interfaces;
using Xunit;

namespace Test.Business.Repos
{
    public class Auth : IAuth
    {
        // Register
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

                mock.Mock<IUserMapping>().Setup(x => x.MapToSsuser(toRegister)).Returns(user);
                mock.Mock<IUserDataRepository>().Setup(x => x.CreateUser(user, toRegister.Password))
                    .Returns(Task.FromResult(ir));
                mock.Mock<IUserDataRepository>().Setup(x => x.AddUserRoleOnRegister(user))
                    .Returns(Task.FromResult(ir));

                var cls = mock.Create<UserRepository>();
                var expected = IdentityResult.Success;
                var actual = await cls.RegisterUser(toRegister);

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
            }
        }

        // Register
        // Login
        [Theory]
        [InlineData("myUserName")]
        [InlineData("test Name")]
        public async Task GetUserForDetailToReturn(string userName)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var userDto = new UserDto { UserName = userName };
                var user = new Ssuser { UserName = userName };
                Expression<Func<Ssuser, bool>> ex = u => u.UserName == userName;

                // mock.Mock<IUserDataRepository>().Setup(x => x.GetUserByUserName(userName)).Returns(ex);
                mock.Mock<IUserDataRepository>().Setup(x => x.Find(u => u.UserName == userName)).Returns(Task.FromResult(user));
                mock.Mock<IUserMapping>().Setup(x => x.MapToUserForDetailDto(user)).Returns(userDto);

                var cls = mock.Create<UserRepository>();
                var expected = new UserDto { UserName = userName };
                var actual = await cls.GetUserForDetailToReturn(userName);

                Assert.True(actual != null);
                Assert.Equal(expected.UserName, actual.UserName);
            }
        }

        // Register
        [Theory]
        [ClassData(typeof(UserData))]
        public async Task GenerateJwtToken(UserDto user)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var roles = new List<string>()
                            {
                                "User",
                                "Artist",
                                "Promoter"
                            };

                var configMock = mock.Mock<IConfigurationSection>();
                configMock.Setup(s => s.Value).Returns("super secret key");

                mock.Mock<IUserDataRepository>().Setup(x => x.GetRolesForUserByUserName(user.UserName))
                    .Returns(Task.FromResult<IEnumerable<string>>(roles));
                mock.Mock<IConfiguration>().Setup(x => x.GetSection("AppSettings:Token"))
                    .Returns(configMock.Object);

                var cls = mock.Create<AuthRepository>();
                var actual = await cls.GenerateJwtToken(user);

                Assert.True(actual != null);
            }
        }

        // Login
        [Theory]
        [ClassData(typeof(UserWithPasswordData))]
        public async Task CheckPasswordSignIn(UserDto dto, string password)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var ssUser = new Ssuser { UserName = dto.UserName };
                Expression<Func<Ssuser, bool>> ex = u => u.UserName == dto.UserName;
                var sr = SignInResult.Success;

                // mock.Mock<IUserDataRepository>().Setup(x => x.GetUserByUserName(user.UserName)).Returns(ex);
                mock.Mock<IUserDataRepository>().Setup(x => x.Add(ssUser));
                mock.Mock<IUserDataRepository>().Setup(x => x.Find(ex)).Returns(Task.FromResult(ssUser));
                mock.Mock<IUserDataRepository>().Setup(x => x.CheckPasswordSignIn(ssUser, password))
                    .Returns(Task.FromResult(sr));

                var cls = mock.Create<AuthRepository>();
                var expected = SignInResult.Success;
                var actual = await cls.CheckPasswordSignIn(dto, password);

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
            }
        }
    }
}