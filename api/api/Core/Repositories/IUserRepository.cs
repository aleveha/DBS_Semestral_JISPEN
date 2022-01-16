using api.Models;

namespace api.Core.Repositories {
    public interface IUserRepository {
        User Get(string email);

        User Add(User user);

        User Verify(User user);
    }
}
