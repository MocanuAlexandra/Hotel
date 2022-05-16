using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    //wrapper class for Admin model that will be used in the view model as a representative
    
    public class AdminVM:BaseViewModel
    {
        private readonly Admin _admin;

        public int AdminId
        {
            get { return _admin.AdminId; }
            set { _admin.AdminId = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return _admin.Email; }
            set { _admin.Email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get { return _admin.Password; }
            set { _admin.Password = value; OnPropertyChanged(); }
        }
        public bool IsActive
        {
            get { return _admin.IsActive; }
            set { _admin.IsActive = value; OnPropertyChanged(); }
        }
        public AdminVM(Admin admin)
        {
            _admin = admin;
        }
              
    }
}
