using Hotel.Models.DataAccesLayer;
using Hotel.Utils;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Welcome_Page_Commands
{
    public class LoginCommand : BaseCommand
    {
        private readonly MainWindowVM _mainWindowViewModel;
        public LoginCommand(MainWindowVM mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object parameter)
        {
            var signInVM = parameter as SignInVM;
            if (parameter is SignInVM)
            {
              
                // verify if Email and Password fileds are empty
                if (string.IsNullOrEmpty(signInVM.Email) || string.IsNullOrEmpty(signInVM.Password))
                {
                    MessageBox.Show("Please fill all fields!", "Login error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // verify if user is admin so we can load the admin view
                // first we check if the format of the email is correct
                if (Utility.IsAdminEmail(signInVM.Email))
                {
                    // then we check if the admin exists in the database
                    if (LoginDAL.IsAdminInDB(signInVM.Email, signInVM.Password) != 0)
                    {
                        _mainWindowViewModel.CurrentViewModel = new AdminMainVM();
                        _mainWindowViewModel.CurrentHeight = Constants.AdminWindowSize.windowHeight;
                        _mainWindowViewModel.CurrentWidth = Constants.AdminWindowSize.windowWidth;
                    }
                }

                // verify if user is employee so we can load the employee view
                else if (Utility.IsEmployeeEmail(signInVM.Email))
                {
                    // then we check if the employee exists in the database
                    if (LoginDAL.IsEmployeeInDB(signInVM.Email, signInVM.Password) != 0)
                    {
                        _mainWindowViewModel.CurrentViewModel = new EmployeeMainVM();
                        _mainWindowViewModel.CurrentHeight = Constants.DefaultWindowSize.windowHeight;
                        _mainWindowViewModel.CurrentWidth = Constants.DefaultWindowSize.windowWidth;
                    }
                }

                // verify if user is guest so we can load the guest view
                else if (Utility.IsClientEmail(signInVM.Email))
                {
                    // then we check if the guest exists in the database
                    if (LoginDAL.IsClientInDB(signInVM.Email, signInVM.Password) != 0)
                    {
                        _mainWindowViewModel.CurrentViewModel = new ClientMainVM();
                        _mainWindowViewModel.CurrentHeight = Constants.DefaultWindowSize.windowHeight;
                        _mainWindowViewModel.CurrentWidth = Constants.DefaultWindowSize.windowWidth;
                    }
                }             

                // if user is not admin or employee or guest, we can't load the view
                // so we show an error message
                else
                    MessageBox.Show("Wrong email or password!", "Login error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
