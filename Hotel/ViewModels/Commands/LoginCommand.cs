﻿using Hotel.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
        }
    }
}
