using System;
using api.Core.Managers;
using api.Core.Repositories;
using api.Models;
using api.Persistence;
using api.Persistence.Repositories;
using api.Helpers.EmailSender;
using api.Helpers.EmailValidation;
using HashCode = api.Helpers.HashCode;

namespace api.App {
    public class AuthorizationManager : IAuthorizationManager {
        private readonly IUserRepository _userRepository;

        public AuthorizationManager(ApplicationContext context) {
            _userRepository = new UserRepository(context);
        }

        public User LogIn(string email, string password) {
            if (!EmailValidator.IsEmailValid(email)) {
                return null;
            }

            User user = _userRepository.Get(email);

            if (user == null) {
                return null;
            }

            string[] passwordParams = user.password.Split(":");
            string hashedPassword = HashCode.Get(password, Convert.FromBase64String(passwordParams[0])).Split(":")[1];

            return hashedPassword == passwordParams[1] ? user : null;
        }

        public User Register(string email, string password) {
            if (!EmailValidator.IsEmailValid(email)) {
                return null;
            }
            
            string confirmationCode = HashCode.GetRandomString(10);
            string hashedPassword = HashCode.Get(password, HashCode.CreateSalt());
            User user = _userRepository.Add(new User(email, hashedPassword, confirmationCode));

            if (user == null) {
                return null;
            }

            EmailSender.SendVerification(email, confirmationCode);

            return user;
        }

        public User ConfirmRegistration(string email, string confirmationCode) {
            if (!EmailValidator.IsEmailValid(email)) {
                return null;
            }
            
            User user = _userRepository.Get(email);

            if (user == null) {
                return null;
            }

            if (user.serviceCode != confirmationCode) {
                return user;
            }

            user.serviceCode = null;
            user.verifiedAt = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

            return _userRepository.Verify(user);
        }
    }
}
