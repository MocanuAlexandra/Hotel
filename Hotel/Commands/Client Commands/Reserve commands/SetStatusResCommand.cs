using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Client_Commands.Reserve_commands
{
    public class SetStatusResCommand:BaseCommand
    {
        private readonly ViewBookingsHistoryVM _viewBookingsHisotryViewModel;
        public SetStatusResCommand(ViewBookingsHistoryVM viewBookingsHisotryViewModel)
        {
            _viewBookingsHisotryViewModel = viewBookingsHisotryViewModel;
            _viewBookingsHisotryViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        //the parameter is the new value of the status
        public override void Execute(object parameter)
        {
            if (parameter is BookingStatus newStatus)
            {
                //change status and update the database
                _viewBookingsHisotryViewModel.SelectedBooking.Status = newStatus;
                BookingDAL.UpdateBooking(_viewBookingsHisotryViewModel.SelectedBooking);

                //update the view
                _viewBookingsHisotryViewModel.ReservationOffers = ReservationOfferDAL.GetReservations(_viewBookingsHisotryViewModel.Client._client);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewBookingsHisotryViewModel.SelectedBooking != null &&
                base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewBookingsHistoryVM.SelectedBooking))
                OnCanExecuteChanged();
        }
    }
}
