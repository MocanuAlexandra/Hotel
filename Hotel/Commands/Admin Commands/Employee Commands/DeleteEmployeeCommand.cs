using Hotel.Models.DataAccesLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Employee_Commands
{
    public class DeleteEmployeeCommand : BaseCommand
    {
        private readonly AdminMainVM _adminMainVM;
        public DeleteEmployeeCommand(AdminMainVM adminMainVM)
        {
            _adminMainVM = adminMainVM;
            _adminMainVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            LoginDAL.DeleteEmployee(_adminMainVM.SelectedEmployee._employee);
            _adminMainVM.Employees.Remove(_adminMainVM.SelectedEmployee);
        }

        public override bool CanExecute(object parameter)
        {
            return _adminMainVM.SelectedEmployee != null && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AdminMainVM.SelectedEmployee))
                OnCanExecuteChanged();
        }
    }
}
