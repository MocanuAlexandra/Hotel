using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hotel.Utils
{
    public class Utility
    {
        #region String manipulation
        
        //check if email format is valid
        public static bool IsEmailFormatOK(string email)
        {
            return Regex.IsMatch(email, Constants.emailFormat);
        }

        //check if email is admin email 
        public static bool IsAdminEmail(string email)
        {
            return Regex.IsMatch(email, Constants.adminEmailFormat);
        }

        // check if email is employee email 
        public static bool IsEmployeeEmail(string email)
        {
            return Regex.IsMatch(email, Constants.employeeEmailFormat);
        }
        
        #endregion
        #region Others
        //interface that is used to close windows from view model
        public interface ICloseWindows
        {
            Action Close { get; set; }
            void CloseWindow();
        }

        #endregion
    }
}

