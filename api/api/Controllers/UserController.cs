using api.App;
using api.Core.Managers;
using api.Models;
using api.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase {
        private readonly IAuthorizationManager _authenticationManager;

        public UserController(ApplicationContext context) {
            _authenticationManager = new AuthorizationManager(context);
        }

        [HttpPost]
        [Route("/users/login")]
        public ActionResult<User> LogIn(string email, string password) {
            User loggedInUser = _authenticationManager.LogIn(email, password);

            if (loggedInUser == null) {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            if (loggedInUser.verifiedAt == null) {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            return Ok(loggedInUser);
        }

        [HttpPost]
        [Route("/users/register")]
        public ActionResult<User> Register(string email, string password) {
            User registeredUser = _authenticationManager.Register(email, password);
            return registeredUser == null ? StatusCode(StatusCodes.Status400BadRequest) : Ok(registeredUser);
        }

        [HttpPost]
        [Route("/users/verify")]
        public ActionResult<User> ConfirmRegistration(string email, string confirmationCode) {
            User confirmedUser = _authenticationManager.ConfirmRegistration(email, confirmationCode);

            if (confirmedUser == null) {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return Ok(confirmedUser);
        }
    }
}
