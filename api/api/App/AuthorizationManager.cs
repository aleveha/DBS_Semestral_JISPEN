using System;
using api.Core;
using api.Models;
using api.Persistence;

namespace api.App
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly IUserRepository _userRepository = new UserRepository();

        public User LogIn(string email, string password)
        {
            User user = _userRepository.Get(email);
            return user != null && password == user.Password ? new User {Email = email, Password = password} : null;
        }

        public User Register(string email, string password)
        {
            string confirmationCode = "12345"; // TODO create hash

            User user = _userRepository.Add(
                new User {Email = email, Password = password, ServiceCode = confirmationCode}
            );

            if (user != null)
            {
                // TODO send verification code to user email
            }

            return user;
        }

        public User ConfirmRegistration(string email, string confirmationCode)
        {
            User userToCheck = _userRepository.Get(email);

            if (userToCheck.ServiceCode != confirmationCode)
                return null;

            return _userRepository.Verify(email, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
        }
    }
}