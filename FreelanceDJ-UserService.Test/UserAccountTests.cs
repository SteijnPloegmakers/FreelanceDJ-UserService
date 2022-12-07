using FreelanceDJ_UserService.Data.Repos;
using FreelanceDJ_UserService.Models.User;
using Moq;
using NUnit.Framework;

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
                    Email = "Karenjanssen@gmail.com"
                },

                new()
                 {
                    Id = new Guid(),
                    Name = "Richard van Zandvoort",
                    Email = "Richardvzandvoort@gmail.com"
                }
            };
        }


        [Test]
        public async Task GetAllUsers_ReturnListWithUsers()
        {
            var data = new Mock<IUserServiceRepository>();
            data.Setup(m => m.GetAllUsers()).ReturnsAsync(_users);
            var userService = new Service.UserService(data.Object);

            var users = await userService.GetAllUserAccounts();

            Assert.AreEqual(users.Count, _users.Count);
        }

        [Test]
        public async Task GetOneSpecificUser_ReturnThisUser()
        {
            var data = new Mock<IUserServiceRepository>();
            data.Setup(m => m.GetSpecificUser(It.IsAny<Guid>())).ReturnsAsync(_users[0]);
            var userService = new Service.UserService(data.Object);

            var user = await userService.GetUserById(It.IsAny<Guid>());

            Assert.AreEqual(user, _users[0]);
        }

        [Test]
        public async Task DeleteOneSpecificUser_ReturnThisUser()
        {
            var data = new Mock<IUserServiceRepository>();
            data.Setup(m => m.DeleteSpecificUser(It.IsAny<Guid>())).ReturnsAsync(_users[0]);
            var userService = new Service.UserService(data.Object);

            var user = await userService.DeleteUserById(It.IsAny<Guid>());

            Assert.AreEqual(user, _users[0]);
        }
    }
}