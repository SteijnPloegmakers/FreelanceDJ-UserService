using FreelanceDJ_UserService.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FreelanceDJ_UserService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
