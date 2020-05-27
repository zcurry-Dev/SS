using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SS.API.Data.Interfaces;

namespace SS.Tests.BusinessLayer
{
    [TestClass]
    public class AuthTest
    {
        private readonly Mock<IAuthDataRepository> _authDataRepository;
        private readonly Mock<IMapper> _autoMapper;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<IUserDataRepository> _userDataRepository;

        public AuthTest()
        {
            _authDataRepository = new Mock<IAuthDataRepository>();
            _autoMapper = new Mock<IMapper>();
            _configuration = new Mock<IConfiguration>();
            _userDataRepository = new Mock<IUserDataRepository>();
        }

        [TestMethod]
        public void Test()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
