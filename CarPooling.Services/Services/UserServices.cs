using CarPooling.Models;
using CarPooling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services.Services
{
    public class UserServices : IUserServices
    {
        public bool AddNewUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            AppDataServices.Users.Add(user);
            return true;
        }

        public User Authentication(Login credentials)
        {
            User user = AppDataServices.Users?.FirstOrDefault(a => a.UserName == credentials.UserName && a.Password == credentials.Password);

            if (user != null)
                return user;

            return null;
        }

        public bool DeleteUser(string id)
        {
            User user = AppDataServices.Users.FirstOrDefault(a => a.Id == id);
            if (user != null)
            {
                AppDataServices.Users.Remove(user);
                return true;
            }

            return false;
        }

        public bool UpdateUserDetails(User newDetails, User oldDetails)
        {
            if (oldDetails != null)
            {
                oldDetails = newDetails;
                return true;
            }

            return false;
        }
    }
}
