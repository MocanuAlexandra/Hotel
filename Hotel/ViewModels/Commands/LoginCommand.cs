﻿using Hotel.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels.Commands
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
                LoginBLL _loginBLL = new LoginBLL(signInVM.Email, signInVM.Password);

                // verify if user is admin so we can load the admin view
                if (_loginBLL.IsAdmin())
                {
                    _mainWindowViewModel.CurrentViewModel = new AdminStartVM();
                }

                // verify if user is employee so we can load the employee view
                else if (_loginBLL.IsEmployee())
                {
                    _mainWindowViewModel.CurrentViewModel = new EmployeeStartVM();
                }

                // if user is not admin or employee or guest, we can't load the view
                // so we show an error message
                else
                    MessageBox.Show("Wrong email or password!", "Login error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
