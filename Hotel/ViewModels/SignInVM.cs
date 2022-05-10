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
        
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                ErrorMessage = "";
                if (!(Utils.Utility.IsEmailFormatOK(email)))
                {
                    ErrorMessage = "INVALID EMAIL FORMAT";
                }
                else
                {
                }
                OnPropertyChanged("Email");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }     
        
        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        
        private LoginBLL _loginBLL;
        public LoginBLL LoginBLL
        {
            get
            {
                return _loginBLL;
            }
            set
            {
                _loginBLL = value;
                OnPropertyChanged("LoginBLL");
            }
        }
        #endregion

        public SignInVM()
        {
            
        }
    }
}
