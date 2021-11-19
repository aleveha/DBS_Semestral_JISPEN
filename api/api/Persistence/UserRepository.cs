using api.Core;
using api.Models;

namespace api.Persistence
{
    public class UserRepository : IUserRepository
    {
        public User Get(string email)
        {
            const string dbEmail = "test@test.com";
            return email == dbEmail ? new User {Email = dbEmail, Password = "1234"} : null;
        }

        public User Add(User user)
        {
            // TODO add new user to DB and if OK return <new User> else null
            return user;
        }

        public User Verify(string email, long verifiedAt)
        {
            // TODO update <verified_at> and delete <service_code>
            return Get(email);
        }

        public User ChangePassword(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}