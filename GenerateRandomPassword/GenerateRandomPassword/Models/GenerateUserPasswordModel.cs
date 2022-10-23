using System;

namespace GenerateRandomPassword.Models
{
    public class GenerateUserPasswordModel
    {
        public string UserId { get; set; }
        public DateTime DateTimeGenerated { get; set; }
        public string Password { get; set; }
    }
}
