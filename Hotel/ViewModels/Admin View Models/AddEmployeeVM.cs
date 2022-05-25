using Hotel.Commands.Admin_Commands.Employee_Commands;
using Hotel.Commands.Navigation_Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels.Admin_View_Models
{
    public class AddEmployeeVM:BaseViewModel, Utils.Utility.ICloseWindows
    {
        #region Properties
        private string _employeeEmail;
        private string _employeePassword;

        public string EmployeeEmail
        {
            get { return _employeeEmail; }
            set
            {
                _employeeEmail = value;
                OnPropertyChanged("EmployeeEmail");
            }
        }

        public string EmployeePassword
        {
            get { return _employeePassword; }
            set
            {
                _employeePassword = value;
                OnPropertyChanged("EmployeePassword");
            }
        }

        #endregion

        #region Commands
        public ICommand CloseCommand { get; private set; }
        public ICommand AddEmployeeCommand { get; private set; }

        #endregion
        
        public AddEmployeeVM(AdminMainVM adminViewModel)
        {
            EmployeeEmail = "";
            EmployeePassword = "";

            CloseCommand = new CloseCommand(this);
            AddEmployeeCommand = new AddEmployeeCommand(this);
        }

        #region Methods
        public Action Close { get; set; }
        public void CloseWindow()
        {
            //if the close action has subscribers, it calls them, closing the 
            //windows that use this viewModel (see MainWindow code-behind)
            Close?.Invoke();
        }
        #endregion
    }
}
