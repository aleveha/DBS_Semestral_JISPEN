using api.Models;

namespace api.Core {
    public interface IUserRepository {
        User Get(string email);

        User Add(User user);

        User Verify(User user);
        // User ChangePassword(User user);
    }
}
