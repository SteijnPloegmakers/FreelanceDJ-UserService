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

        public UserController(IUserService userService)
        {
            _userService = userService;
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
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddDjAccount(AddUser addUser)
        {
            var user = await _userService.AddUser(addUser);
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUserAccount([FromRoute] Guid id)
        {
            var user = await _userService.DeleteUserById(id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
    }
}
