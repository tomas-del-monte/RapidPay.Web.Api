using Microsoft.AspNetCore.Identity;

namespace RapidPay.Web.Api.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            var hasher = new PasswordHasher<object>();
            string hashedPassword = hasher.HashPassword(null, password);

            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPasswordWithSalt)
        {
            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, hashedPasswordWithSalt, password);

            return result == PasswordVerificationResult.Success;
        }
    }
}
