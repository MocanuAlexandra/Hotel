using Hotel.Models.DataAccesLayer;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Models.BusinessLogicLayer
{
    public class LoginBLL
    {
        private string _email;
        private string _password;

        public LoginBLL(string email, string password)
        {
            _email = email;
            _password = password;
        }

        readonly LoginDAL loginDAL = new LoginDAL();

        // verify if user is admin
        public bool IsAdmin()
        {
            // first we check if the format of the email is correct
            if (Utility.IsAdminEmail(_email))
            {
                // then we check if the admin exists in the database
                if (loginDAL.IsAdminInDB(_email, _password) != 0)
                    return true;
                else
                    return false;
            }
            //if the email format is not correct we return false since the user is not an admin
            return false;
        }

        // verify if user is employee
        public bool IsEmployee()
        {
            // first we check if the format of the email is correct
            if (Utility.IsEmployeeEmail(_email))
            {
                // then we check if the employee exists in the database
                if (loginDAL.IsEmployeeInDB(_email, _password) != 0)
                    return true;
                else
                    return false;
            }
            //if the email format is not correct we return false since the user is not an employee
            return false;
        }

        // verify if user is guest
        public bool IsGuest()
        {
            // first we check if the format of the email is correct
            if (Utility.IsGuestEmail(_email))
            {
                // then we check if the guest exists in the database
                if (loginDAL.IsGuestInDB(_email, _password) != 0)
                    return true;
                else
                    return false;
            }
            //if the email format is not correct we return false since the user is not a guest
            return false;
        }
    }
}
