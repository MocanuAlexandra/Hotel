using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    public class BookingVM:BaseViewModel
    {
        public readonly Booking _booking;

        public int Id
        {
            get { return _booking.Id; }
        }
        public int ClientId
        {
            get { return _booking.ClientId; }
            set { _booking.ClientId = value; OnPropertyChanged(); }
        }
        public Client Client
        {
            get { return _booking.Client; }
            set { _booking.Client = value; OnPropertyChanged(); }
        }

        public DateTime CheckInDate
        {
            get { return _booking.CheckInDate; }
            set { _booking.CheckInDate = value; OnPropertyChanged(); }
        }

        public DateTime CheckOutDate
        {
            get { return _booking.CheckOutDate; }
            set { _booking.CheckOutDate = value; OnPropertyChanged(); }
        }


        public float TotalPrice
        {
            get { return _booking.TotalPrice; }
            set { _booking.TotalPrice = value; OnPropertyChanged(); }
        }
        public BookingStatus Status
        {
            get { return _booking.Status; }
            set { _booking.Status = value; OnPropertyChanged(); }
        }

        public List<int> RoomsIds
        {
            get { return _booking.RoomsIds; }
            set { _booking.RoomsIds = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Room> Rooms
        {
            get { return _booking.Rooms; }
            set { _booking.Rooms = value; OnPropertyChanged(); }
        }

        public List<int> HotelServicesIds
        {
            get { return _booking.HotelServicesIds; }
            set { _booking.HotelServicesIds = value; OnPropertyChanged(); }
        }
        public ObservableCollection<HotelService> HotelServices
        {
            get { return _booking.HotelServices; }
            set { _booking.HotelServices = value; OnPropertyChanged(); }
        }

        public bool IsActive
        {
            get { return _booking.IsActive; }
            set { _booking.IsActive = value; OnPropertyChanged(); }
        }

        public BookingVM(Booking booking)
        {
            _booking = booking;
        }        
    }
}

