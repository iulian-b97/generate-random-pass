using System;

namespace GenerateRandomPassword.Models
{
    public class CheckUserPasswordModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool IsValidPassword { get; set; }
        public bool SamePasswords { get; set; }
    }
}
