using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    //wrapper class for Employee model that will be used in the view model as a representative

    public class EmployeeVM:BaseViewModel
    {
        public Employee _employee;

        public int Id
        {
            get { return _employee.EmployeeId; }
            set
            {
                _employee.EmployeeId = value;
                OnPropertyChanged("Id");
            }
        }

        public string Email
        {
            get { return _employee.Email; }
            set
            {
                _employee.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Password
        {
            get { return _employee.Password; }
            set
            {
                _employee.Password = value;
                OnPropertyChanged("Password");
            }
        }

        public bool  IsActive
        {
            get { return _employee.IsActive; }
            set
            {
                _employee.IsActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        public EmployeeVM(Employee employee)
        {
            _employee = employee;
        }
    }
}
