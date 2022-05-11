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

            if (registerDAL.CanRegisterGuest(_firstname, _lastname, _email, _password, _phone))
                return true;
            else
                return false;
        }
    }
}
