using AutoMapper;
using GenerateRandomPassword.AppData;
using GenerateRandomPassword.AppData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenerateRandomPassword.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;

        public UserRepository(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public User GetUserById(string userId)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
            return user;
        }

        public IList<User> GetUsers()
        {
            IList<User> users = _dbContext.Users.ToList();
            return users;
        }

        public bool ExistUser(string userId)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
            if(user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateUser(User user)
        {
            if(user != null)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateUserPassword(string userId, string password, DateTime date)
        {
            if(userId != null)
            {
                User user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
                user.Password = password;
                user.DateTimeGenerated = date;

                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
            }
        }

        public bool IsValidPassword(string userId)
        {
            if(userId == null)
            {
                return false;         
            }

            User user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
            if(user == null)
            {
                return false;
            }

            var diffInSeconds = (DateTime.Now - user.DateTimeGenerated).TotalSeconds;
            if(diffInSeconds > 30)
            {
                return false;
            }

            return true;
        }
    }
}
