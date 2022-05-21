using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class ClientMainVM : BaseViewModel
    {
        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }
        public ObservableCollection<HotelServicesVM> HotelServices { get; set; }
        public ObservableCollection<FacilityVM> Facilities { get; set; }
        public ObservableCollection<OfferVM> Offers { get; set; }
        public ClientMainVM()
        {
            // read the room types, create wrapers and populate the list
            RoomTypes = new ObservableCollection<RoomTypeVM>();
            foreach (var roomType in RoomTypeDAL.GetRoomTypes())
                RoomTypes.Add(new RoomTypeVM(roomType));

            // read the hotel services, create wrapers and populate the list
            HotelServices = new ObservableCollection<HotelServicesVM>();
            foreach (var hotelService in HotelServiceDAL.GetHotelServices())
                HotelServices.Add(new HotelServicesVM(hotelService));

            // read the offers, create wrapers and populate the list
            Offers = new ObservableCollection<OfferVM>();
            foreach (var offer in OfferDAL.GetAllOffers())
                Offers.Add(new OfferVM(offer));
        }
    }
}
