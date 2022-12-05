using FreelanceDJ_UserService.Models.User;

namespace FreelanceDJ_UserService.Service
{
    public interface IUserService
    {
        Task<List<User>> GetAllUserAccounts();
    }
}
