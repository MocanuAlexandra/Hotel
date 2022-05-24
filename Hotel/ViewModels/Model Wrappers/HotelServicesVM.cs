using Hotel.Models.EntityLayer;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    //wrapper class for Hotel services model that will be used in the view model as a representative
    public class HotelServicesVM : BaseViewModel, IBookingItem
    {
        public readonly HotelService _hotelService;

        public int Id
        {
            get { return _hotelService.Id; }
            set { _hotelService.Id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return _hotelService.Name; }
            set { _hotelService.Name = value; OnPropertyChanged(); }
        }

        public float Price
        {
            get { return _hotelService.Price; }
            set { _hotelService.Price = value; OnPropertyChanged(); }
        }
        public bool IsActive
        {
            get { return _hotelService.IsActive; }
            set { _hotelService.IsActive = value; OnPropertyChanged(); }
        }

        public List<int> AssignedReservationsIds
        {
            get { return _hotelService.AssignedReservationsIds; }
            set { _hotelService.AssignedReservationsIds = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Booking> AssignedReservations
        {
            get { return _hotelService.AssignedReservations; }
            set { _hotelService.AssignedReservations = value; OnPropertyChanged(); }
        }

        #region Booking item properties
        public string ItemName { get => "Hotel service"; }

        private uint _itemQuantity;
        public uint ItemQuantity
        {
            get { return _itemQuantity; }
            set { _itemQuantity = value; OnPropertyChanged(); }
        }

        //services do not depend on the time period, they have a fixed price
        public float TotalPriceForPeriod
        {
            get { return Price; }
            set { /*empty*/ }
        }

        #endregion
        public HotelServicesVM(HotelService hotelService)
        {
            _hotelService = hotelService;
        }
    }
}

