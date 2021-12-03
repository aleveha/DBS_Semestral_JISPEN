using System.Linq;
using api.Core;
using api.Models;

namespace api.Persistence.Repositories {
    public class UserRepository : IUserRepository {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context) {
            _context = context;
        }

        public User Get(string email) {
            return _context.users.SingleOrDefault(user => user.email.Equals(email));
        }

        public User Add(User user) {
            if (Get(user.email) != null) {
                return null;
            }

            _context.Add(user);
            _context.SaveChanges();
            return Get(user.email);
        }

        public User Verify(User user) {
            _context.users.Update(user);
            _context.SaveChanges();
            return Get(user.email);
        }

        // public User ChangePassword(User user) {
        //     throw new System.NotImplementedException();
        // }
    }
}
