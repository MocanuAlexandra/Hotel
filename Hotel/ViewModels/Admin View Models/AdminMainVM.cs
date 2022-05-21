using Hotel.Commands.Admin_Commands;
using Hotel.Commands.Admin_Commands.Hotel_services_Commands;
using Hotel.Commands.Admin_Commands.Offers_Commands;
using Hotel.Commands.Admin_Commands.Offers_Commands.CRUD_Offer_Commands;
using Hotel.Commands.Admin_Commands.Room_Commands;
using Hotel.Commands.Admin_Commands.Room_Facilities_Commands;
using Hotel.Commands.Admin_Commands.Room_Facilities_Commands.CRUD_RoomFacilities_Commands;
using Hotel.Commands.Admin_Commands.RoomFacilities_Commands;
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
    public class AdminMainVM : BaseViewModel
    {
        #region Properties
        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }
        public ObservableCollection<HotelServicesVM> HotelServices { get; set; }
        public ObservableCollection<FacilityVM> Facilities { get; set; }
        public ObservableCollection<OfferVM> Offers { get; set; }
        

        private RoomTypeVM _selectedRoomType;
        public RoomTypeVM SelectedRoomType
        {
            get { return _selectedRoomType; }
            set { _selectedRoomType = value; OnPropertyChanged(); }
        }
  
        private HotelServicesVM _selectedHotelService;
        public HotelServicesVM SelectedHotelService
        {
            get { return _selectedHotelService; }
            set { _selectedHotelService = value; OnPropertyChanged(); }
        }
  
        private FacilityVM _selectedFacility;
        public FacilityVM SelectedFacility
        {
            get { return _selectedFacility; }
            set { _selectedFacility = value; OnPropertyChanged(); }
        }
       
        private OfferVM _selectedOffer;
        public OfferVM SelectedOffer
        {
            get { return _selectedOffer; }
            set { _selectedOffer = value; OnPropertyChanged(); }
        }

        #endregion
        
        #region Commands

        // room type commands
        public ICommand OpenAddRoomTypeWindowCommand { get; set; }
        public ICommand OpenEditRoomTypeWindowCommand { get; set; }
        public ICommand DeleteRoomTypeCommand { get; set; }

        // room commands
        public ICommand OpenAddRoomWindowCommand { get; set; }
        public ICommand OpenRemoveRoomWindowCommand { get; set; }

        // hotel service commands
        public ICommand OpenEditServiceWindowCommand { get; set; }
        public ICommand OpenAddServiceWindowCommand { get; set; }
        public ICommand DeleteHotelServiceCommand { get; set; }
        public ICommand OpenAssignHotelServiceCommand { get; set; }

        // facility commands
        public ICommand OpenAddRoomFacilityWindowCommand { get; set; }
        public ICommand OpenEditRoomFacilityWindowCommand { get; set; }
        public ICommand DeleteRoomFacilityCommand { get; set; }
        public ICommand OpenAssignRoomFacilityCommand { get; set; }

        // offers commands
        public ICommand OpenAddOfferWindowCommand { get; set; }
        public ICommand OpenEditOfferWindowCommand { get; set; }
        public ICommand DeleteOfferCommand { get; set; }

        #endregion

        public AdminMainVM()
        {
            OpenAddRoomTypeWindowCommand = new OpenAddRoomTypeWindowCommand(this);
            OpenEditRoomTypeWindowCommand = new OpenEditRoomTypeWindowCommand(this);
            DeleteRoomTypeCommand = new DeleteRoomTypeCommand(this);

            OpenAddRoomWindowCommand = new OpenAddRoomWindowCommand(this);
            OpenRemoveRoomWindowCommand = new OpenRemoveRoomWindowCommand(this);

            OpenEditServiceWindowCommand = new OpenEditServiceWindowCommand(this);
            OpenAddServiceWindowCommand = new OpenAddServiceWindowCommand(this);
            DeleteHotelServiceCommand = new DeleteHotelServiceCommand(this);
            OpenAssignHotelServiceCommand = new OpenAssignHotelServiceCommand(this);

            OpenAddRoomFacilityWindowCommand = new OpenAddRoomFacilityWindowCommand(this);
            OpenEditRoomFacilityWindowCommand = new OpenEditRoomFacilityWindowCommand(this);
            DeleteRoomFacilityCommand = new DeleteRoomFacilityCommand(this);
            OpenAssignRoomFacilityCommand = new OpenAssignRoomFacilityCommand(this);

            OpenAddOfferWindowCommand = new OpenAddOfferWindowCommand(this);
            OpenEditOfferWindowCommand = new OpenEditOfferWindowCommand(this);
            DeleteOfferCommand = new DeleteOfferCommand(this);

            //read the room types, create wrapers and populate the list
            RoomTypes = new ObservableCollection<RoomTypeVM>();
            foreach (var roomType in RoomTypeDAL.GetRoomTypes())
                RoomTypes.Add(new RoomTypeVM(roomType));

            // read the hotel services, create wrapers and populate the list
            HotelServices = new ObservableCollection<HotelServicesVM>();
            foreach (var hotelService in HotelServiceDAL.GetHotelServices())
                HotelServices.Add(new HotelServicesVM(hotelService));

            //read the facilities, create wrapers and populate the list
            Facilities = new ObservableCollection<FacilityVM>();
            foreach (var facility in FacilityDAL.GetFacilities())
                Facilities.Add(new FacilityVM(facility));

            //read the offers, create wrapers and populate the list
            Offers = new ObservableCollection<OfferVM>();
            foreach (var offer in OfferDAL.GetAllOffers())
                Offers.Add(new OfferVM(offer));
        }
    }
}
