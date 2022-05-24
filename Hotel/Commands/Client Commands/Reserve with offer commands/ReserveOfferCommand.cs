using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Client_Commands
{
    public class ReserveOfferCommand : BaseCommand
    {
        public readonly ClientMainVM _clientViewModel;

        public ReserveOfferCommand(ClientMainVM clientMainVM)
        {
            _clientViewModel = clientMainVM;
            _clientViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            //first we have to chekc out if there is any available room
            // for this client 
            var availableRooms = RoomDAL.GetAvailableRooms(
                        _clientViewModel.SelectedOffer.CheckInDate,
                        _clientViewModel.SelectedOffer.CheckOutDate.AddDays(-1),
                        _clientViewModel.SelectedOffer.AssignedRoomType);

            // if no room is available, we cannot make the reservation
            if (availableRooms.Count() < 1)
            {
                MessageBox.Show($"There is room available left for this offer",
                             "Cannot make reservation",
                             MessageBoxButton.OK,
                             MessageBoxImage.Warning);
                return;
            }

            // create the new reservation
            ReservationOffer reservation = new ReservationOffer
            {
                Client = _clientViewModel.Client._client,
                ClientId = _clientViewModel.Client._client.ClientId,
                Offer = _clientViewModel.SelectedOffer._offer,
                OfferId = _clientViewModel.SelectedOffer._offer.Id,
                Room = availableRooms.First(),
                RoomId = availableRooms.First().Id,
                Status = ReservationStatus.Active,
                IsActive = true,
            };
            
            // add the room to the reservation and save it to database
            ReservationOfferDAL.CreateReservation(_clientViewModel.Client._client,
                _clientViewModel.SelectedOffer._offer,
                availableRooms.First(),
                reservation);

            // update the client's reservationsbookings history view
            //_clientViewModel.ViewBookingsHistoryVM.ReservationOffers.Add(reservation);

            MessageBox.Show("Offer booked successfully!", "Success", MessageBoxButton.OK,
                   MessageBoxImage.Information);            
        }

        public override bool CanExecute(object parameter)
        {
            return _clientViewModel.SelectedOffer != null && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ClientMainVM.SelectedOffer))
                OnCanExecuteChanged();
        }
    }
}
