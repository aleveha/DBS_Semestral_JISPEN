using System;
using System.IO;
using api.Core.Managers;
using api.Core.Repositories;
using api.Models;
using api.Persistence;
using api.Persistence.Repositories;
using api.Helpers.EmailSender;
using api.Helpers.EmailValidation;
using api.Helpers.HashUtility;

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

            string[] userPasswordHashedString = user.password.Split(":");

            return IsPasswordCorrect(userPasswordHashedString[1], password, userPasswordHashedString[0]) ? user : null;
        }

        public User Register(string email, string password) {
            if (!EmailValidator.IsEmailValid(email)) {
                return null;
            }

            string confirmationCode = HashUtility.GetRandomString(10);
            User user = _userRepository.Add(new User(email, HashUtility.GetHash(password), confirmationCode));

            if (user == null) {
                return null;
            }

            EmailSender.SendEmail(
            email,
            "Potvrzení registrace v aplikaci JISPEN",
            File.ReadAllText("./Helpers/EmailSender/verificationTemplate.html").Replace("{code}", confirmationCode));

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

        private static bool IsPasswordCorrect(string userPasswordHash, string inputPassword, string salt) {
            return userPasswordHash == HashUtility.GetHash(inputPassword, Convert.FromBase64String(salt)).Split(":")[1];
        }
    }
}
