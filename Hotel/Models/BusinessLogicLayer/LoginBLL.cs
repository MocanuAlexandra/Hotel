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

        public LoginBLL(string username, string password)
        {
            _email = username;
            _password = password;
        }

        readonly LoginDAL loginDAL = new LoginDAL();

        // verify if user is admin
        public bool IsAdmin()
        {
            // first we check if the format of the email is correct
            if (Regex.IsMatch(_email, Constants.adminEmailFormat))
            {
                // then we check if the admin exists in the database
                if (loginDAL.LoginAdmin(_email, _password))
                    return true;
                else
                    MessageBox.Show("Wrong email or password!");

            }
            return false;
        }
    }
}
