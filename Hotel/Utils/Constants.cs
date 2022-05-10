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
        #endregion

        #region Const strings
        public static string adminEmailFormat = "@admin-hotel.com$|@adminhotel.com$";
        public static string employeeEmailFormat = "@employee-hotel.com$|@employeehotel.com$";
        public static string emailFormat = "^[A-Za-z0-9._]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$";
        #endregion
    }
}
