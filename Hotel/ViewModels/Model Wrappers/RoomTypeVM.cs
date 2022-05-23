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
    //wrapper class for RoomType model that will be used in the view model as a representative
    public class RoomTypeVM : BaseViewModel,IBookingItem
    {
        public readonly RoomType _roomType;

        public int Id
        {
            get { return _roomType.Id; }
            set { _roomType.Id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return _roomType.Name; }
            set { _roomType.Name = value; OnPropertyChanged(); }
        }
        public int Capacity
        {
            get { return _roomType.Capacity; }
            set { _roomType.Capacity = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Room> RoomsOfType
        {
            get { return _roomType.RoomsOfType; }
            set { _roomType.RoomsOfType = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Facility> Facilities
        {
            get { return _roomType.Facilities; }
            set { _roomType.Facilities = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Price> Prices
        {
            get { return _roomType.Prices; }
            set { _roomType.Prices = value; OnPropertyChanged(); }
        }            
        public bool IsActive
        {
            get { return _roomType.IsActive; }
            set { _roomType.IsActive = value; OnPropertyChanged(); }
        }

        //not in the base model, used to display the total price when the user is searching a certain
        //period
        private float _totalPriceForPeriod;
        public float TotalPriceForPeriod
        {
            get { return _totalPriceForPeriod; }
            set { _totalPriceForPeriod = value; OnPropertyChanged(); }
        }

        #region Booking item properties
        public string ItemName { get => "Room Type"; }

        private uint _itemQuantity;
        public uint ItemQuantity
        {
            get { return _itemQuantity; }
            set { _itemQuantity = value; OnPropertyChanged(); }
        }
        #endregion
        
        public RoomTypeVM(RoomType roomType)
        {
            _roomType = roomType;
        }
    }
}
