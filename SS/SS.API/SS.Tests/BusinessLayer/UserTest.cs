using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SS.API.Business.Dtos.Return;
using SS.API.Business.Interfaces;
using SS.API.Business.Repos;
using SS.API.Data.Interfaces;
using SS.API.Data.Models;

namespace SS.Tests
{
    [TestClass]
    public class UserTest
    {
        private readonly Mock<IUserDataRepository> _userDataRepository;
        private readonly Mock<IMapper> _autoMapper;

        public UserTest()
        {
            _userDataRepository = new Mock<IUserDataRepository>();
            _autoMapper = new Mock<IMapper>();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task NullReferenceExceptionThrownIfUserDoesNotExist()
        {
            //Arrange
            int userId = 0;
            _userDataRepository.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(() => null);

            var userRepository = new UserRepository(_userDataRepository.Object, _autoMapper.Object);

            //Act
            var user = await userRepository.GetUserById(userId);

            //Assert
            Assert.IsInstanceOfType(user, typeof(UserForDetailDto));
        }

        [TestMethod]
        public async Task ReturnTypeOfUserForDetailDto()
        {
            //Arrange                 
            int userId = 0;
            _userDataRepository.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(new Ssuser()));
            _autoMapper.Setup(x => x.Map<UserForDetailDto>(It.IsAny<Ssuser>())).Returns(new UserForDetailDto());

            var userRepository = new UserRepository(_userDataRepository.Object, _autoMapper.Object);

            //Act
            var user = await userRepository.GetUserById(userId);

            //Assert
            Assert.IsInstanceOfType(user, typeof(UserForDetailDto));
        }
    }
}
