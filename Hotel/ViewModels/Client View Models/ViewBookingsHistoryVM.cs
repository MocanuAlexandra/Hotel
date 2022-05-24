using Hotel.Commands.Client_Commands;
using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    public class ViewBookingsHistoryVM : BaseViewModel
    {
        public MainWindowVM MainWindowVM { get; set; }
        
        private ClientVM _client;
        public ClientVM Client
        {
            get { return _client; }
            set
            {
                _client = value;
                OnPropertyChanged("Client");
            }
        }

        public ObservableCollection<ReservationOffer> ReservationOffers { get; set;  }
   
        private ReservationOffer _selectedReservationOffer;
        public ReservationOffer SelectedReservationOffer
        {
            get { return _selectedReservationOffer; }
            set
            {
                _selectedReservationOffer = value;
                OnPropertyChanged("SelectedReservationOffer");
            }
        }
        public ICommand SetStatusResOfferCommand { get; set; }

        public ViewBookingsHistoryVM(MainWindowVM mainWindowVM)
        {
            MainWindowVM = mainWindowVM;            
            ReservationOffers = new ObservableCollection<ReservationOffer>();

            // commands
            SetStatusResOfferCommand = new SetStatusResOfferCommand(this);          

        }
    }
}
