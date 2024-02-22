using Xunit;
using Moq;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.View;
using UkukhulaAPI.Data.Services;
using Microsoft.EntityFrameworkCore;
using UkukhulaAPI.Data;

namespace UkukhulaAPI.Tests
{
    public class UsersServiceTests
    {
        [Fact]
        public void AddUser_Returns_True_When_User_Added_Successfully()
        {
            // Arrange
            var user = new UserRegistrationVm
            {
                FirstName = "John",
                LastName = "Doe",
                Idnumber = "1234567890"
            };

            var contact = new ContactVm
            {
                ContactNumber = "1234567890",
                Email = "john.doe@example.com"
            };

            var options = new DbContextOptionsBuilder<UkukhulaContext>()
                .UseInMemoryDatabase(databaseName: "UkukhulaTestDatabase")
                .Options;

            using (var context = new UkukhulaContext(options))
            {
                var service = new UsersService(context);

                // Act
                var result = service.AddUser(user, contact);

                // Assert
                Assert.True(result);
            }
        }

        [Fact]
        public void FindUser_Returns_LoginVm_When_User_Found()
        {
            // Arrange
            var username = "1234567890";
            var user = new User
            {
                Idnumber = username
            };

            var mockSet = new Mock<DbSet<User>>();
            mockSet.Setup(m => m.FirstOrDefault(u => u.Idnumber == username)).Returns(user);

            var mockContext = new Mock<UkukhulaContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var service = new UsersService(mockContext.Object);

            // Act
            var result = service.findUser(username);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(username, result.Username);
            Assert.Equal("", result.Password); // Assuming the password is empty in this case
        }

        [Fact]
        public void FindUser_Returns_Null_When_User_Not_Found()
        {
            // Arrange
            var username = "nonexistentusername";

            var mockSet = new Mock<DbSet<User>>();
            mockSet.Setup(m => m.FirstOrDefault(u => u.Idnumber == username)).Returns((User)null);

            var mockContext = new Mock<UkukhulaContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var service = new UsersService(mockContext.Object);

            // Act
            var result = service.findUser(username);

            // Assert
            Assert.Null(result);
        }
    }
}
