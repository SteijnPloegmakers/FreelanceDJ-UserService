using FreelanceDJ_UserService.Models.User;

namespace FreelanceDJ_UserService.Service
{
    public interface IUserService
    {
        Task<List<User>> GetAllUserAccounts();
        Task<User> GetUserById(Guid id);
        Task<AddUser> AddUser(AddUser addUser);
        Task<User> DeleteUserById(Guid id);
    }
}
