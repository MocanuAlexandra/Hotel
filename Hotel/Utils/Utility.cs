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

        //check if email is guest email
        public static bool IsClientEmail(string email)
        {
            return Regex.IsMatch(email, Constants.clientEmailFormat);
        }

        //check if name is valid
        public static bool IsValidName(string name)
        {
            return Regex.IsMatch(name, Constants.nameFormat);
        }

        // check if phone number is valid
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, Constants.phoneNumberFormat);
        }

        //check if password and confirm password are same
        public static bool IsPasswordSame(string password, string confirmPassword)
        {
            return password.Equals(confirmPassword);
        }

        // hash a password
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // check if password is correct
        public static bool CheckPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }


        //checks if the room type name is valid
        public static bool CheckIfRoomTypeNameIsValid(string roomTypeName)
        {
            if (string.IsNullOrEmpty(roomTypeName) || roomTypeName.Length < 1)
                return false;
            return Regex.IsMatch(roomTypeName, "^[- _]*[a-zA-Z0-9][- a-zA-Z0-9_]*$");
        }

        // check if hotel service is valid
        public static bool CheckIfHotelServiceIsValid(string hotelService)
        {
            if (string.IsNullOrEmpty(hotelService) || hotelService.Length < 1)
                return false;
            return Regex.IsMatch(hotelService, "^[- _]*[a-zA-Z0-9][- a-zA-Z0-9_]*$");
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

