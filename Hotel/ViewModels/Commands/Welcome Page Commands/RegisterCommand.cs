using Hotel.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels.Commands
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
                RegisterBLL _registerBLL = new RegisterBLL(signUpVM.FirstName,
                    signUpVM.LastName, signUpVM.Email, signUpVM.Password, signUpVM.Phone);

                // verify if fields are empty
                if (string.IsNullOrEmpty(signUpVM.FirstName) || string.IsNullOrEmpty(signUpVM.LastName) ||
                    string.IsNullOrEmpty(signUpVM.Email) || string.IsNullOrEmpty(signUpVM.Password) ||
                    string.IsNullOrEmpty(signUpVM.ConfirmPassword) || string.IsNullOrEmpty(signUpVM.Phone))
                {
                    MessageBox.Show("Please fill all fields!", "Register error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
              
                // verify if we can register the user
                if (_registerBLL.RegisterSucceded())
                {
                    _mainWindowViewModel.CurrentViewModel = new ClientMainVM();
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