using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SS.Business.Mappings.Interfaces;
using SS.Business.Models.User;
using SS.Business.Repos;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Tests.BusinessLayer
{
    [TestClass]
    public class UserTest
    {

        private readonly UserRepository _userRepository;
        private readonly Mock<IUserDataRepository> _userDataRepository;
        private readonly Mock<IUserMapping> _map;

        public UserTest()
        {
            _userDataRepository = new Mock<IUserDataRepository>();
            _map = new Mock<IUserMapping>();
            _userRepository = new UserRepository(_userDataRepository.Object, _map.Object);
        }

        #region userRepository.GetUserById
        [TestMethod]
        public async Task GetUserById_ReturnTypeOf_UserForDetailDto()
        {
            //Arrange
            _userDataRepository.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(new Ssuser()));
            _map.Setup(x => x.MapToUserForDetailDto(It.IsAny<Ssuser>())).Returns(new UserForDetailDto());

            //Act
            var result = await _userRepository.GetUserById(It.IsAny<int>());

            //Assert
            Assert.IsInstanceOfType(result, typeof(UserForDetailDto));
        }

        [TestMethod]
        public async Task GetUserById_IfUserDoesNotExist_NullReferenceExceptionThrown()
        {
            //Arrange
            _userDataRepository.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(() => null);

            //Assert
            await Assert.ThrowsExceptionAsync<NullReferenceException>(async () =>
            {
                await _userRepository.GetUserById(It.IsAny<int>());
            });
        }

        [TestMethod]
        public async Task GetUserById_IfMappingDoesNotExist_NullReferenceExceptionThrown()
        {
            //Arrange
            _userDataRepository.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(new Ssuser()));
            _map.Setup(x => x.MapToUserForDetailDto(It.IsAny<Ssuser>())).Returns(() => null);

            //Assert
            await Assert.ThrowsExceptionAsync<NullReferenceException>(async () =>
            {
                await _userRepository.GetUserById(It.IsAny<int>());
            });
        }

        [TestMethod]
        public async Task GetUserById_ExecuteMethodsOnlyOnce()
        {
            //Arrange
            _userDataRepository.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(Task.FromResult(new Ssuser()));
            _map.Setup(x => x.MapToUserForDetailDto(It.IsAny<Ssuser>())).Returns(new UserForDetailDto());

            //Act
            var result = await _userRepository.GetUserById(It.IsAny<int>());

            //Assert
            _userDataRepository.Verify(u => u.GetUserById(It.IsAny<string>()), Times.Once());
            _map.Verify(m => m.MapToUserForDetailDto(It.IsAny<Ssuser>()), Times.Once());
        }
        #endregion userRepository.GetUserById

        #region userRepository.RegisterUser
        [TestMethod]
        public async Task RegisterUser_IfMappingDoesNotExist_NullReferenceExceptionThrown()
        {
            //Arrange
            _map.Setup(x => x.MapToSsuser(It.IsAny<UserForRegisterDto>())).Returns(() => null);

            //Assert
            await Assert.ThrowsExceptionAsync<NullReferenceException>(async () =>
            {
                await _userRepository.RegisterUser(It.IsAny<UserForRegisterDto>());
            });
        }

        #endregion
        // Assert.AreEqual
        // Assert.AreNotEqual
        // Assert.AreNotSame
        // Assert.AreSame
        // Assert.Equals
        // Assert.Fail
        // Assert.Inconclusive
        // Assert.IsFalse
        // Assert.IsInstanceOfType
        // Assert.IsNotInstanceOfType
        // Assert.IsNotNull
        // Assert.IsNull
        // Assert.IsTrue
        // Assert.ReplaceNullChars
        // Assert.ThrowsException
    }
}
