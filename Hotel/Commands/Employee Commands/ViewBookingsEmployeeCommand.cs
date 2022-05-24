using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Employee_Commands
{
    public class ViewBookingsEmployeeCommand : BaseCommand
    {
        private readonly EmployeeMainVM _employeeMainVM;

        public ViewBookingsEmployeeCommand(EmployeeMainVM employeeMainVM)
        {
            _employeeMainVM = employeeMainVM;
        }

        public override void Execute(object parameter)
        {
            _employeeMainVM.MainWindowVM.CurrentViewModel=
                new ViewAllBookingsVM(_employeeMainVM.MainWindowVM);
        }

    }
}
