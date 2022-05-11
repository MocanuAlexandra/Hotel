using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Utils
{
    public static class Constants
    {
        #region Window sizes
        public struct DefaultWindowSize
        {
            public const int windowWidth = 500;
            public const int windowHeight = 500;
        }

        public struct SignUpWindowSize
        {
            public const int windowWidth = 500;
            public const int windowHeight = 800;
        }
        #endregion

        #region Const strings
        public static string adminEmailFormat = "@admin-hotel.com$|@adminhotel.com$";
        public static string employeeEmailFormat = "@employee-hotel.com$|@employeehotel.com$";
        public static string guestEmailFormat = "@gmail.com$|yahoo.com$|hotmail.com$|outlook.com$";
        public static string emailFormat = "^[A-Za-z0-9._]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$";

        public static string nameFormat = "^[A-Z]{1}[a-z]+$";
        public static string phoneNumberFormat = @"^(?<paren>\()?0(?:(?:72|74|75|76|77|78)(?(paren)\))(?<first>\d)(?!\k<first>{6})\d{6}|(?:251|351)(?(paren)\))(?<first>\d)(?!\k<first>{5})\d{5})$";
        #endregion
    }
}
