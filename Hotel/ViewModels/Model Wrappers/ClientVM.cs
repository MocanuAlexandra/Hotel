using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    //wrapper class for Client model that will be used in the view model as a representative
    public class ClientVM : BaseViewModel
    {
        public readonly Client _client;
        public int ClientId
        {
            get { return _client.ClientId; }
            set { _client.ClientId = value; OnPropertyChanged(); }
        }

        public string FirstName
        {
            get { return _client.FirstName; }
            set { _client.FirstName = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get { return _client.LastName; }
            set { _client.LastName = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return _client.Email; }
            set { _client.Email = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get { return _client.Password; }
            set { _client.Password = value; OnPropertyChanged(); }
        }
        public string Phone
        {
            get { return _client.Phone; }
            set { _client.Phone = value; OnPropertyChanged(); }
        }
        public bool IsActive
        {
            get { return _client.IsActive; }
            set { _client.IsActive = value; OnPropertyChanged(); }
        }
        public ClientVM(Client guest)
        {
            _client = guest;
        }
    }
}
