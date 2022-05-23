using Hotel.Models.EntityLayer;
using Hotel.Utils;
using System;
using System.Collections.Generic;
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

        #region Booking item properties
        public string ItemName { get => "Hotel service"; }

        private uint _itemQuantity;
        public uint ItemQuantity
        {
            get { return _itemQuantity; }
            set { _itemQuantity = value; OnPropertyChanged(); }
        }

        //not in the base model, used to display the total price when the user is searching a certain
        //period
        private float _totalPriceForPeriod;
        public float TotalPriceForPeriod
        {
            get { return _totalPriceForPeriod; }
            set { _totalPriceForPeriod = value; OnPropertyChanged(); }
        }
        
        #endregion
        public HotelServicesVM(HotelService hotelService)
        {
            _hotelService = hotelService;
        }
    }
}

