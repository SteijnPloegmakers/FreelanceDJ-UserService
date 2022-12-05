namespace FreelanceDJ_UserService.Models.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string GoogleId { get; set; }
    }
}
