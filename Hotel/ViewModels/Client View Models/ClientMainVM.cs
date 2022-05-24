using Hotel.Commands.Client_Commands;
using Hotel.Models.DataAccesLayer;
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
    public class ClientMainVM : BaseViewModel
    {
        #region Properties

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

        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }

        public ObservableCollection<OfferVM> Offers { get; set; }
        private OfferVM _selectedOffer;
        public OfferVM SelectedOffer
        {
            get { return _selectedOffer; }
            set
            {
                _selectedOffer = value;
                OnPropertyChanged("SelectedOffer");
            }
        }       
        
        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged(); }
        }

        private double _noOfNights;
        public double NoOfNights
        {
            get { return _noOfNights; }
            set { _noOfNights = value; OnPropertyChanged(); }
        }

        //public ViewBookingsHistoryVM ViewBookingsHistoryVM { get; set; }
        public MainWindowVM MainWindowVM { get; set; }
        #endregion

        public ICommand SearchCommand { get; private set; }
        public ICommand ViewBookingsHistoryCommand { get; private set; }

        public ICommand MakeBookingCommand { get; private set; }
        public ICommand ReserveOfferCommand { get; private set; }        

        public ClientMainVM()
        {         
            StartDate = DateTime.Today;

            SearchCommand = new SearchCommand(this);
            ViewBookingsHistoryCommand = new ViewBookingsHistoryCommand(this);
            MakeBookingCommand = new MakeBookingCommand(this);
            ReserveOfferCommand = new ReserveOfferCommand(this);

            // read the room types, create wrapers and populate the list
            RoomTypes = new ObservableCollection<RoomTypeVM>();
            foreach (var roomType in RoomTypeDAL.GetRoomTypes())
                RoomTypes.Add(new RoomTypeVM(roomType));

            // read the offers, create wrapers and populate the list
            Offers = new ObservableCollection<OfferVM>();
            foreach (var offer in OfferDAL.GetAllOffers())
                Offers.Add(new OfferVM(offer));
        }
    }
}
