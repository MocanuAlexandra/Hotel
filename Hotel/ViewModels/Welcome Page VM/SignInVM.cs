using Hotel.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class SignInVM : BaseViewModel
    {

        #region DataMembers

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
                if (!(Utils.Utility.IsEmailFormatOK(_email)))
                {
                    ErrorMessage = "INVALID EMAIL FORMAT";
                }
                OnPropertyChanged("Email");
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

        public SignInVM()
        {

        }
    }
}
