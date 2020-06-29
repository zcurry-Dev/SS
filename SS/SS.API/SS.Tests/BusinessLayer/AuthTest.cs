using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SS.Business.Mappings.Interfaces;
using SS.Data.Interfaces;

namespace SS.Tests.BusinessLayer
{
    [TestClass]
    public class AuthTest
    {
        private readonly Mock<IAuthDataRepository> _authDataRepository;
        private readonly Mock<IAuthMapping> _map;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<IUserDataRepository> _userDataRepository;

        public AuthTest()
        {
            _authDataRepository = new Mock<IAuthDataRepository>();
            _map = new Mock<IAuthMapping>();
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
