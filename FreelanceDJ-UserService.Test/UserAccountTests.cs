using FreelanceDJ_UserService.Data.Repos;
using FreelanceDJ_UserService.Models.User;
using Moq;
using NUnit.Framework;
using System.Security.Principal;

namespace FreelanceDJ_UserService.Test
{
    public class UserAccountTests
    {
        private readonly List<User> _users;

        public UserAccountTests()
        {
            _users = new List<User>
            {
                new()
                {
                    Id = new Guid(),
                    Name = "Karen Janssen",
                    Email = "Karenjanssen@gmail.com",
                    GoogleId = "teewt43343trdfger2223"
                },

                new()
                 {
                    Id = new Guid(),
                    Name = "Richard van Zandvoort",
                    Email = "Richardvzandvoort@gmail.com",
                    GoogleId = "qrgj93u383r48sfdsh4"
                }
            };
        }


        [Test]
        public async Task GetAllDjs_ReturnListWithDjs()
        {
            //Arrange
            var data = new Mock<IUserServiceRepository>();
            data.Setup(m => m.GetAllUsers()).ReturnsAsync(_users);

            var userService = new Service.UserService(data.Object);

            //Act
            var users = await userService.GetAllUserAccounts();

            //Arrange
            Assert.AreEqual(users.Count, _users.Count);
        }
    }
}