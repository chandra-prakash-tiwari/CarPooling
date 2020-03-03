using CarPooling.Models;
using CarPooling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services.Services
{
    public class UserService : IUserService
    {
        public bool AddNewUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            AppDataService.Users.Add(user);
            return true;
        }

        public User Authentication(Login credentials)
        {
            if(credentials != null)
            {
                User user = AppDataService.Users?.FirstOrDefault(a => a.UserName == credentials.UserName && a.Password == credentials.Password);
                if (user != null)
                    return user;
            }

            return null;
        }

        public bool DeleteUser(string id)
        {
            User user = AppDataService.Users.FirstOrDefault(a => a.Id == id);
            if (user != null)
            {
                AppDataService.Users.Remove(user);
                return true;
            }

            return false;
        }

        public User GetUser(string id)
        {
            return AppDataService.Users.FirstOrDefault(a => a.Id == id);
        }
    }
}
