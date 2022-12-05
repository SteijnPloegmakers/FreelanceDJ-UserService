using FreelanceDJ_UserService.Data.Repos;
using FreelanceDJ_UserService.Models.User;

namespace FreelanceDJ_UserService.Service
{
    public class UserService : IUserService
    {
        private readonly IUserServiceRepository _userServiceRepository;

        public UserService(IUserServiceRepository userServiceRepository)
        {
            _userServiceRepository = userServiceRepository;
        }

        public async Task<List<User>> GetAllUserAccounts()
        {
            return await _userServiceRepository.GetAllUsers();
        }
    }
}
