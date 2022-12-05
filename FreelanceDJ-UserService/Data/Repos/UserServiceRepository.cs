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
    }
}
