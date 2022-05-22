using Hotel.Commands.Client_Commands;
using Hotel.Models.DataAccessLayer;
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
        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }
        public ObservableCollection<FacilityVM> Facilities { get; set; }
        public ObservableCollection<OfferVM> Offers { get; set; }

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

        #endregion

        public ICommand SearchCommand { get; private set; }
        
        public ClientMainVM()
        {
            StartDate = DateTime.Today;

            SearchCommand = new SearchCommand(this);
            
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
