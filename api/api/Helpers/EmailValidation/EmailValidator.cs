using System.Text.RegularExpressions;

namespace api.Helpers.EmailValidation {
    public static class EmailValidator {
        public static bool IsEmailValid(string email) {
            return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(email).Success;
        }
    }
}
