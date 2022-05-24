﻿
using Hotel.Models.DataAccesLayer;
using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.Utils;
using Hotel.ViewModels;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Welcome_Page_Commands
{
    public class RegisterCommand : BaseCommand
    {
        private readonly MainWindowVM _mainWindowViewModel;
        public RegisterCommand(MainWindowVM mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object parameter)
        {
            var signUpVM = parameter as SignUpVM;
            if (parameter is SignUpVM)
            {
                // verify if fields are empty
                if (string.IsNullOrEmpty(signUpVM.FirstName) || string.IsNullOrEmpty(signUpVM.LastName) ||
                    string.IsNullOrEmpty(signUpVM.Email) || string.IsNullOrEmpty(signUpVM.Password) ||
                    string.IsNullOrEmpty(signUpVM.ConfirmPassword) || string.IsNullOrEmpty(signUpVM.Phone))
                {
                    MessageBox.Show("Please fill all fields!", "Register error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // first we hash the password
                // then we check if the email is already in the database
                // if it is not, we add the user to the database and return true
                string hashedPassword = Utility.HashPassword(signUpVM.Password);
                if (RegisterDAL.CanRegisterClient(signUpVM.FirstName, signUpVM.LastName, signUpVM.Email,
                    hashedPassword, signUpVM.Phone))
                {
                    Client client = LoginDAL.GetClient(signUpVM.Email, signUpVM.Password);
                    
                    _mainWindowViewModel.CurrentViewModel = new ClientMainVM()
                    {
                        Client = new ClientVM(client),
                        MainWindowVM = _mainWindowViewModel,
                    };
                    _mainWindowViewModel.CurrentHeight = Constants.ClientWindowSize.windowHeight;
                    _mainWindowViewModel.CurrentWidth = Constants.ClientWindowSize.windowWidth;
                }
                else
                {
                    MessageBox.Show("User already exists!", "Register error",
                       MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}