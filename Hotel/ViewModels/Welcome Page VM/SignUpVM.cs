using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class SignUpVM : BaseViewModel
    {
        #region Properties

        private string _firstname;
        public string FirstName
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                ErrorMessage = "";
                if (!Utility.IsValidName(_firstname))
                {
                    ErrorMessage = "INVALID FIRST NAME";
                }
                OnPropertyChanged("FirstName");
            }

        }

        private string _lastname;
        public string LastName
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                ErrorMessage = "";
                if (!Utility.IsValidName(_lastname))
                {
                    ErrorMessage = "INVALID LAST NAME";
                }
                OnPropertyChanged("FLAstName");
            }

        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                ErrorMessage = "";
                if (!Utility.IsClientEmail(_email))
                {
                    ErrorMessage = "INVALID EMAIL FORMAT";
                }
                OnPropertyChanged("Email");
            }
        }

        private string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                ErrorMessage = "";
                if (!Utility.IsValidPhoneNumber(_phone))
                {
                    ErrorMessage = "INVALID PHONE FORMAT";
                }
                OnPropertyChanged("Phone");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                ErrorMessage = "";
                if (!Utility.IsPasswordSame(_password, _confirmPassword))
                {
                    ErrorMessage = "PASSWORDS DO NOT MATCH";
                }
                OnPropertyChanged("ConfirmPassword");
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        #endregion
    }
}
