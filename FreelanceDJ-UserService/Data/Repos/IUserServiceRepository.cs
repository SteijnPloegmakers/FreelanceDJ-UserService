using FreelanceDJ_UserService.Models.User;

namespace FreelanceDJ_UserService.Data.Repos
{
    public interface IUserServiceRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetSpecificUser(Guid id);
        Task<AddUser> AddNewUser(AddUser addUser);
        Task<User> DeleteSpecificUser(Guid id);

    }
}
