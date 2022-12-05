using FreelanceDJ_UserService.Models.User;

namespace FreelanceDJ_UserService.Data.Repos
{
    public interface IUserServiceRepository
    {
        Task<List<User>> GetAllUsers();
    }
}
