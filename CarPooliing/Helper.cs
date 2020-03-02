using CarPooling.Models;
using CarPooling.Services;
using CarPooling.Services.Services;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CarPooling
{
    public class Helper
    {
        public static string ValidString()
        {
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine(Constant.InValidInput);
                str = ValidString();
            }

            return str;
        }

        public static int ValidInteger()
        {
            if (!Int32.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine(Constant.InValidInput);
                number = ValidInteger();
            }

            return number;
        }

        public static DateTime ValidDate()
        {
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine(Constant.InValidDate);
                date = ValidDate();
            }

            return date;
        }

        public static string GetValidEmail()
        {
            string email = Console.ReadLine();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (string.IsNullOrEmpty(email) || !match.Success)
            {
                Console.WriteLine(Constant.InValidInput);
                email = GetValidEmail();
            }

            return email;
        }

        public static string GetValidUserName()
        {
            string userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName) || (AppDataServices.Users.FirstOrDefault(a=>a.UserName==userName)!=null))
            {
                Console.WriteLine(Constant.UserNameNotAvailable);
                userName = GetValidUserName();
            }

            return userName;
        }

        public static string GetValidCity()
        {
            string cityName = Console.ReadLine();
            if (CitiesInfo.Cities?.FirstOrDefault(a => a.City.Equals(cityName, StringComparison.InvariantCultureIgnoreCase)) == null)
            {
                Console.WriteLine(Constant.InValidInput);
                cityName = GetValidCity();
                return cityName;
            }

            return cityName;
        }

        public static float GetValidFloat()
        {
            if (!float.TryParse(Console.ReadLine(), out float number))
            {
                Console.WriteLine(Constant.InValidInput);
                number = ValidInteger();
            }

            return number;
        }
    }
}
