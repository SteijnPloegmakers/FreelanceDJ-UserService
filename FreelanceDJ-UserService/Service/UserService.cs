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

        public async Task<User> GetUserById(Guid id)
        {
            return await _userServiceRepository.GetSpecificUser(id);
        }

        public async Task<AddUser> AddUser(AddUser addUser)
        {
            return await _userServiceRepository.AddNewUser(addUser);
        }

        public async Task<User> DeleteUserById(Guid id)
        {
            return await _userServiceRepository.DeleteSpecificUser(id);
        }
    }
}
