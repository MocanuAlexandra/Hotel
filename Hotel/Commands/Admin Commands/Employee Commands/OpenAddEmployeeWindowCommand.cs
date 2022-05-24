using Hotel.ViewModels;
using Hotel.ViewModels.Admin_View_Models;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Employee_Commands
{
    public class OpenAddEmployeeWindowCommand:BaseCommand
    {
        private readonly AdminMainVM _adminMainVM;
        public OpenAddEmployeeWindowCommand(AdminMainVM adminMainVM)
        {
            _adminMainVM = adminMainVM;
        }

        public override void Execute(object parameter)
        {
            AddEmployeeWindow addEmployeeWindowView = new AddEmployeeWindow()
            {
                DataContext = new AddEmployeeVM(_adminMainVM)
            };
            addEmployeeWindowView.ShowDialog();
        }

    }
}
