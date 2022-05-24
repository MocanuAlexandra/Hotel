using Hotel.Commands.Client_Commands;
using Hotel.Commands.Client_Commands.Reserve_commands;
using Hotel.Commands.Client_Commands.Reserve_commands.Hotel_Services;
using Hotel.Models.Bussines_Data_Layer;
using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.Utils;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    public class MakeBookingVM : BaseViewModel, Utility.ICloseWindows
    {
        public BookingVM BookingVM { get; set; }
        public ClientVM Client { get; set; }

        //used to display the list of items that the user has added
        #region ItemList

        private IBookingItem _selectedBookingItem;
        public IBookingItem SelectedBookingItem
        {
            get { return _selectedBookingItem; }
            set { _selectedBookingItem = value; OnPropertyChanged(); }
        }
        public ObservableCollection<IBookingItem> BookingItems { get; set; }

        #endregion

        //used by the combobox to allow the user to add items to the reservation
        #region Available items (room tyes and services)

        private RoomTypeVM _selectedRoomType;
        public RoomTypeVM SelectedRoomType
        {
            get { return _selectedRoomType; }
            set { _selectedRoomType = value; OnPropertyChanged(); }
        }
        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }

        private HotelServicesVM _selectedService;
        public HotelServicesVM SelectedService
        {
            get { return _selectedService; }
            set { _selectedService = value; OnPropertyChanged(); }
        }
        public ObservableCollection<HotelServicesVM> Services { get; set; }

        #endregion

        #region Commands
        public ICommand AddRoomTypeItemCommand { get; private set; }
        public ICommand AddServiceItemCommand { get; private set; }
        public ICommand RemoveBookingItemCommand { get; private set; }
        public ICommand SubmitBookingCommand { get; private set; }
        #endregion

        public MakeBookingVM(ClientVM client)
        {
            Client = client;

            //make a list of items that the client has added to the booking
            //needs to be initialized before the commands, the submit reservation command
            //has a method subscribed to the 'CollectionChanged' event of this list
            BookingItems = new ObservableCollection<IBookingItem>();

            //create dummy reservation that we will modify before commiting
            BookingVM = new BookingVM(
                new Booking()
                {
                    Client = client._client,
                    ClientId = client.ClientId,

                    CheckInDate = DateTime.Today,
                    CheckOutDate = DateTime.Today.AddDays(1),

                    TotalPrice = 0,
                    Status = BookingStatus.Active,

                    RoomsIds = new List<int>(),
                    Rooms = new ObservableCollection<Room>(),

                    HotelServicesIds = new List<int>(),
                    HotelServices = new ObservableCollection<HotelService>(),

                    IsActive = true,
                });
            BookingVM.PropertyChanged += BookingVM_PropertyChanged;


            // commands
            AddRoomTypeItemCommand = new AddRoomTypeCommand(this);
            RemoveBookingItemCommand = new RemoveBookingItemCommand(this);
            AddServiceItemCommand = new AddServiceCommand(this);
            SubmitBookingCommand = new SubmitBookingCommand(this);

            //read all room types from the database            
            RoomTypes = new ObservableCollection<RoomTypeVM>();
            foreach (var roomType in RoomTypeDAL.GetRoomTypes())
                RoomTypes.Add(new RoomTypeVM(roomType));
            SelectedRoomType = RoomTypes.FirstOrDefault();


            //read all services from the database
            Services = new ObservableCollection<HotelServicesVM>();
            foreach (var service in HotelServiceDAL.GetHotelServices())
                Services.Add(new HotelServicesVM(service));
            SelectedService = Services.FirstOrDefault();
        }
        
        #region Methods        

        //used to detect when the check in and no of nights have changed
        //and recalculate the total price
        private void BookingVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BookingVM.CheckInDate) ||
                e.PropertyName == nameof(BookingVM.CheckOutDate))
            {

                foreach (var item in BookingItems)
                    if (item is RoomTypeVM roomType)
                    {
                        //read the prices for the new time period
                        roomType.Prices = PriceDAL.GetPricesInInterval(roomType.Id,
                            BookingVM.CheckInDate,
                            BookingVM.CheckOutDate.AddDays(- 1));

                        roomType.TotalPriceForPeriod =
                            RoomTypeBLL.CalculatePriceForTimeInterval(roomType.Prices,
                            BookingVM.CheckInDate,
                            BookingVM.CheckOutDate.AddDays(-1))
                            * roomType.ItemQuantity;
                    }

                BookingVM.TotalPrice = BookingItems.Sum(x => x.TotalPriceForPeriod);
            }
        }
        public void RoomTypeVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if the item quantity changed, we need to recalculate the total price of the reservation
            if (e.PropertyName == nameof(RoomTypeVM.ItemQuantity))
                BookingVM.TotalPrice = BookingItems.Sum(x => x.TotalPriceForPeriod);
        }
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

