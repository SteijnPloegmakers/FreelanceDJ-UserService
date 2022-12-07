using FreelanceDJ_UserService.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FreelanceDJ_UserService.Data.Repos
{
    public class UserServiceRepository : IUserServiceRepository
    {
        private readonly DataContext _dataContext;

        public UserServiceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User> GetSpecificUser(Guid id)
        {
            return await _dataContext.Users.FirstAsync(x => x.Id == id);
        }

        public async Task<AddUser> AddNewUser(AddUser addUser)
        {
            var ifEmailAlreadyExists = _dataContext.Users.Any(x => x.Email == addUser.Email);

            if (ifEmailAlreadyExists)
            {
                return addUser;
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = addUser.Name,
                Email = addUser.Email
            };

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return addUser;
        }

        public async Task<User> DeleteSpecificUser(Guid id)
        {
            var user = await _dataContext.Users.FirstAsync(x => x.Id == id);
            _dataContext.Remove(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }
    }
}
