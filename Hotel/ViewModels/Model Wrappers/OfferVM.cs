using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    //wrapper class for Offer model that will be used in the view model as a representative 
    public class OfferVM:BaseViewModel
    {
        public readonly Offer _offer;
        public int Id
        {
            get { return _offer.Id; }
            set { _offer.Id = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get { return _offer.Description; }
            set { _offer.Description = value; OnPropertyChanged(); }
        }
        
        public DateTime CheckInDate
        {
            get { return _offer.CheckInDate; }
            set { _offer.CheckInDate = value; OnPropertyChanged(); }
        }

        public DateTime CheckOutDate
        {
            get { return _offer.CheckOutDate; }
            set { _offer.CheckOutDate = value; OnPropertyChanged(); }
        }

        public float Price
        {
            get { return _offer.Price; }
            set { _offer.Price = value; OnPropertyChanged(); }
        }
        public bool IsActive
        {
            get { return _offer.IsActive; }
            set { _offer.IsActive = value; OnPropertyChanged(); }
        }
        public ObservableCollection<HotelService> HotelServices
        {
            get { return _offer.HotelServices; }
            set { _offer.HotelServices = value; OnPropertyChanged(); }
        }
        public RoomType AssignedRoomType
        {
            get { return _offer.AssignedRoomType; }
            set { _offer.AssignedRoomType = value; OnPropertyChanged(); }
        }
        
        public OfferVM(Offer offer)
        {
            _offer = offer;
        }
        

    }
}
