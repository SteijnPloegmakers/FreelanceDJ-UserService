using Microsoft.AspNetCore.Mvc;

namespace FreelanceDJ_UserService.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
