using Hotel.Models.DataAccessLayer;
using Hotel.Utils;
using Hotel.ViewModels.Admin_View_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Admin_Commands.Employee_Commands
{
    public class AddEmployeeCommand : BaseCommand
    {
        private readonly AddEmployeeVM _addEmployeeVM;
        public AddEmployeeCommand(AddEmployeeVM addEmployeeVM)
        {
            _addEmployeeVM = addEmployeeVM;
            _addEmployeeVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            //firt we check if the email is valid
            if (!Utility.IsEmployeeEmail(_addEmployeeVM.EmployeeEmail))
            {
                MessageBox.Show("Email is not valid!", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            else
            {
                // first we hash the password
                // then we check if the email is already in the database
                // if it is not, we add the employee to the database
                string hashedPassword = Utility.HashPassword(_addEmployeeVM.EmployeePassword);
                if (RegisterDAL.CanRegisterEmployee(_addEmployeeVM.EmployeeEmail, hashedPassword))
                {
                    MessageBox.Show("Employee hired successfully!", "Success", MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    // after adding the employee, we close the window
                    _addEmployeeVM.CloseWindow();
                }
                else
                {
                    MessageBox.Show("Employee already exists!", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }               
            }                
        }


        public override bool CanExecute(object parameter)
        {
            return _addEmployeeVM.EmployeeEmail != null &&
                !string.IsNullOrEmpty(_addEmployeeVM.EmployeePassword) &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddEmployeeVM.EmployeeEmail)
                || e.PropertyName == nameof(AddEmployeeVM.EmployeePassword))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
