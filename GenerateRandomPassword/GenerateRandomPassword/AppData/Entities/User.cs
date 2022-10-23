using System;

namespace GenerateRandomPassword.AppData.Entities
{
    public class User
    {
        public string UserId { get; set; }
        public DateTime DateTimeGenerated { get; set; }
        public string Password { get; set; }
    }
}
