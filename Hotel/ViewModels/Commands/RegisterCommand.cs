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

                // verify if we can register the user
                if (_registerBLL.RegisterSucceded())
                {
                    _mainWindowViewModel.CurrentViewModel = new GuestStartVM();
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