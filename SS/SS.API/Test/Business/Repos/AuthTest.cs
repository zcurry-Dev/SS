using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using SS.Business.Interfaces;
using SS.Business.Models.User;
using SS.Business.Repos;
using SS.Data.Interfaces;
using SS.Data.Models;
using Test.Business.ClassData;
using Test.Business.Interfaces;
using Xunit;

namespace Test.Business.Repos
{
    public class AuthTest : IAuthTest
    {
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

                mock.Mock<IUserData>().Setup(x => x.GetRolesFromUserAsync(user.UserName))
                    .Returns(Task.FromResult<IEnumerable<string>>(roles));
                mock.Mock<IConfiguration>().Setup(x => x.GetSection("AppSettings:Token"))
                    .Returns(configMock.Object);

                var cls = mock.Create<AuthRepo>();
                var actual = await cls.GenerateJwtTokenAsync(user);

                Assert.True(actual != null);
            }
        }

        [Theory]
        [ClassData(typeof(UserWithPasswordData))]
        public async Task CheckPasswordSignIn(UserDto dto, string password)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var user = new Ssuser { UserName = dto.UserName };
                var sr = SignInResult.Success;

                // Expression<Func<Ssuser, bool>> ex = u => u.UserName == dto.UserName;
                // // would like to test with ^^this^^ but don't think I'm able to
                // mock.Mock<IUserDataRepository>().Setup(x => x.Find(ex)).Returns(Task.FromResult(user));

                mock.Mock<IUserData>().Setup(x => x.FindAsync(It.IsAny<Expression<Func<Ssuser, bool>>>()))
                    .Returns(Task.FromResult(user));
                mock.Mock<IUserData>().Setup(x => x.CheckPasswordSignInAsync(user, password))
                    .Returns(Task.FromResult(sr));

                var cls = mock.Create<AuthRepo>();
                var expected = SignInResult.Success;
                var actual = await cls.CheckPasswordSignInAsync(dto, password);

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
            }
        }
    }
}