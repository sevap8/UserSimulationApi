using Moq;
using NUnit.Framework;
using UserSimulation.Core.Models;
using UserSimulation.Core.Repositories;
using UserSimulation.Core.Services;

namespace UserSimulation.Core.Tests
{
    public class UserServiceTests
    {
        [Test]
        public void ShouldAddNewUser()
        {
            // Arrange
            var mock = new Mock<IUserRepositories>();
            var userService = new UserService(mock.Object);
            UserEntity userEntity = new UserEntity
            {
                Id = 1,
                Name = "SomeName",
                Surname = "SomeSurname"
            };

            // Act
            userService.AddUser(userEntity);

            // Assert
            mock.Verify(a => a.Add(It.Is<UserEntity>(a => a.Id == 1 && a.Name == "SomeName" && a.Surname == "SomeSurname")));
        }

        [Test]
        public void ShouldGetUserById()
        {
            // Arrange
            var mock = new Mock<IUserRepositories>();
            var id = 1;
            UserEntity userEntity = new UserEntity
            {
                Id = 1,
                Name = "SomeName",
                Surname = "SomeSurname"
            };
            mock.Setup(a => a.Get(It.IsAny<int>())).Returns(userEntity);
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var userService = new UserService(mock.Object);

            // Act
            var entity = userService.GetUserById(id);

            // Assert
            Assert.AreEqual(entity, userEntity);
        }

        [Test]
        public void ShouldPutUser()
        {
            // Arrange
            var mock = new Mock<IUserRepositories>();
            var id = 1;
            UserEntity userEntity = new UserEntity
            {
                Id = 4,
                Name = "SomeName",
                Surname = "SomeSurname"
            };
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var userService = new UserService(mock.Object);

            // Act
            userService.PutUserById(id, userEntity);

            // Assert
            mock.Verify(a => a.Put(It.Is<int>(a => a == id), It.Is<UserEntity>(a => a.Id == 4 && a.Name == "SomeName" && a.Surname == "SomeSurname")));
        }
    }
}