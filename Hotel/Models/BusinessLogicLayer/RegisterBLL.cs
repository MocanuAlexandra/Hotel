using Hotel.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.BusinessLogicLayer
{
    public class RegisterBLL
    {
        private string _firstname;
        private string _lastname;
        private string _email;
        private string _password;
        private string _phone;

        public RegisterBLL(string firstname, string lastname, string email, string password, string phone)
        {
            _firstname = firstname;
            _lastname = lastname;
            _email = email;
            _password = password;
            _phone = phone;
        }

        readonly RegisterDAL registerDAL = new RegisterDAL();

        public bool RegisterSucceded()
        {
            // first we hash the password
            // then we check if the email is already in the database
            // if it is, we return false
            // if it is not, we add the user to the database and return true
            
            string hashedPassword = Utils.Utility.HashPassword(_password);
            if (registerDAL.CanRegisterGuest(_firstname, _lastname, _email, hashedPassword, _phone))
                return true;
            else
                return false;
        }
    }
}
