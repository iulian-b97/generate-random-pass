using BCrypt.Net;
using GenerateRandomPassword.AppData.Entities;
using GenerateRandomPassword.Models;
using GenerateRandomPassword.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GenerateRandomPassword.Controllers
{
    public class UserPasswordController : Controller
    {
        private IUserRepository _userRepository;

        public UserPasswordController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenerateUserPassword(GenerateUserPasswordModel model)
        {
            if(model.UserId != null)
            {
                model.DateTimeGenerated = DateTime.Now;
                model.Password = GenerateRandomPassword(16);

                if(_userRepository.ExistUser(model.UserId) == false)
                {
                    User newUser = new User
                    {
                        UserId = model.UserId,
                        DateTimeGenerated = model.DateTimeGenerated,
                        Password = CryptPassword(model.Password)
                    };
                    _userRepository.CreateUser(newUser);
                }
                else
                {
                    string cryptPassword = CryptPassword(model.Password);
                    _userRepository.UpdateUserPassword(model.UserId, cryptPassword, model.DateTimeGenerated);
                }
            }
            
            return View(model);
        }

        public IActionResult CheckUserPassword(CheckUserPasswordModel model)
        {
            if ((model.UserId != null) && (model.Password != null))
            {
                User user = _userRepository.GetUserById(model.UserId);

                if((user.UserId != null) && (user.Password != null))
                {
                    if (BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                    {
                        model.SamePasswords = true;
                    }

                    if(_userRepository.IsValidPassword(model.UserId))
                    {
                        model.IsValidPassword = true;
                    }
                }
            }
            
            return View(model);
        }


        public static string GenerateRandomPassword(int length)
        {
            const string alphanumericCharacters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789";
            return GetRandomString(length, alphanumericCharacters);
        }

        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8)
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }

        public string CryptPassword(string password)
        {
            if(password == null)
            {
                return null;
            }

            string cryptPassword = BCrypt.Net.BCrypt.HashPassword(password);
            if(BCrypt.Net.BCrypt.Verify(password, cryptPassword))
            {
                return cryptPassword;
            }

            return null;
        }
    }
}
