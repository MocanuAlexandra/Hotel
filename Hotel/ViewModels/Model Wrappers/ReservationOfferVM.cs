using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    public class ReservationOfferVM:BaseViewModel
    {
        public readonly ReservationOffer _reservationOffer;

        public int Id
        {
            get { return _reservationOffer.Id; }
            set
            {
                _reservationOffer.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public int ClientId
        {
            get { return _reservationOffer.ClientId; }
            set
            {
                _reservationOffer.ClientId = value;
                OnPropertyChanged("ClientId");
            }
        }
            
        public Client Client
        {
            get { return _reservationOffer.Client; }
            set
            {
                _reservationOffer.Client = value;
                OnPropertyChanged("Client");
            }
        }

        public int RoomId
        {
            get { return _reservationOffer.RoomId; }
            set
            {
                _reservationOffer.RoomId = value;
                OnPropertyChanged("RoomId");
            }
        }

        public Room Room
        {
            get { return _reservationOffer.Room; }
            set
            {
                _reservationOffer.Room = value;
                OnPropertyChanged("Room");
            }
        }
        public int _offerId;
        public int OfferId
        {
            get { return _offerId; }
            set
            {
                _offerId = value;
                OnPropertyChanged("OfferId");
            }
        }
        public Offer Offer
        {
            get { return _reservationOffer.Offer; }
            set
            {
                _reservationOffer.Offer = value;
                OnPropertyChanged("Offer");
            }
        }
        public bool IsActive
        {
            get { return _reservationOffer.IsActive; }
            set
            {
                _reservationOffer.IsActive = value;
                OnPropertyChanged("IsActive");
            }
        }
        public ReservationOffer.ReservationStatus Status
        {
            get { return _reservationOffer.Status; }
            set { _reservationOffer.Status = value; OnPropertyChanged(); }
        }

        public ReservationOfferVM(ReservationOffer reservationOffer)
        {
            _reservationOffer = reservationOffer;
        }
    }
}
