using Microsoft.AspNetCore.Mvc;
using Seguradora.src.Auth;
using Seguradora.src.User;

namespace Seguradora.src.Auth
{
    [Route ("api/[controller]")]
    public class LoginController : Controller {
        private readonly IUserService _userService;

        public LoginController (IUserService userService) {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login ([FromBody] Login auth) {
            if (auth == null) {
                throw new System.ArgumentNullException (nameof (auth));
            }

            src.User.User user = _userService.GetByAuth(auth);
            if(user == null) {
                return Unauthorized();
            }

            return new OkObjectResult(user);
        }
    }
}