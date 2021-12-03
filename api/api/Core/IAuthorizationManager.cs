using api.Models;

namespace api.Core {
    public interface IAuthorizationManager {
        User LogIn(string email, string password);
        User Register(string email, string password);

        User ConfirmRegistration(string email, string confirmationCode);
        // User ChangePassword(string email);
    }
}
