using api.App;
using api.Core;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthorizationManager _authenticationManager = new AuthorizationManager();

        [HttpPost]
        [Route("/[controller]/login")]
        public ActionResult<User> LogIn(string email, string password)
        {
            User loggedInUser = _authenticationManager.LogIn(email, password);
            return loggedInUser == null ? StatusCode(StatusCodes.Status401Unauthorized) : Ok(loggedInUser);
        }

        [HttpPost]
        [Route("/[controller]/register")]
        public ActionResult<User> Register(string email, string password)
        {
            User registeredUser = _authenticationManager.Register(email, password);
            return registeredUser == null ? StatusCode(StatusCodes.Status500InternalServerError) : Ok(registeredUser);
        }

        [HttpPost]
        [Route("/[controller]/confirm")]
        public ActionResult<User> ConfirmRegistration(string email, string confirmationCode)
        {
            User confirmedUser = _authenticationManager.ConfirmRegistration(email, confirmationCode);
            return confirmedUser == null ? StatusCode(StatusCodes.Status401Unauthorized) : Ok(confirmedUser);
        }

        // [HttpPost]
        // public ActionResult<User> ChangePassword(string email)
        // {
        //     User registeredUser = _authenticationManager.(email);
        //     return registeredUser == null ? StatusCode(StatusCodes.Status401Unauthorized) : Ok(registeredUser);
        // }
    }
}