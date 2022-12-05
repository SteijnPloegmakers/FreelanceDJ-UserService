using FreelanceDJ_UserService.Data;
using FreelanceDJ_UserService.Models.User;
using FreelanceDJ_UserService.Service;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceDJ_UserService.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly DataContext _dataContext;

        public UserController(IUserService userService, DataContext dataContext)
        {
            _userService = userService;
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await _userService.GetAllUserAccounts();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var users = await _dataContext.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddDjAccount(AddUser addUser)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = addUser.Name,
                Email = addUser.Email,
                GoogleId = addUser.GoogleId
            };

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return Ok(user);
        }
    }
}
