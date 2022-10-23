using GenerateRandomPassword.AppData.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GenerateRandomPassword.Repositories
{
    public interface IUserRepository
    {
        public User GetUserById(string userId);
        public IList<User> GetUsers();
        public bool ExistUser(string userId);
        public void CreateUser(User user);
        public void UpdateUserPassword(string userId, string password, DateTime date);
        public bool IsValidPassword(string userId);
    }
}
