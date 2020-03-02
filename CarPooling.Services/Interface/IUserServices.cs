using CarPooling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPooling.Services.Interfaces
{
    public interface IUserServices
    {
        bool AddNewUser(User user);

        User Authentication(Login credentials);

        bool DeleteUser(string id);

        bool UpdateUserDetails(User newDetails, User oldDetails);
    }
}
