using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Client_Commands
{
    public class SetStatusResOfferCommand:BaseCommand
    {
        private readonly ViewBookingsHistoryVM _viewBookingsHisotryViewModel;
        public SetStatusResOfferCommand(ViewBookingsHistoryVM viewBookingsHisotryViewModel)
        {
            _viewBookingsHisotryViewModel = viewBookingsHisotryViewModel;
            _viewBookingsHisotryViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        //the parameter is the new value of the status
        public override void Execute(object parameter)
        {
            if (parameter is ReservationStatus newStatus)
            {
                //change status and update the database
                _viewBookingsHisotryViewModel.SelectedReservationOffer.Status = newStatus;
                ReservationOfferDAL.UpdateReservation(_viewBookingsHisotryViewModel.SelectedReservationOffer);

                //update the view
                _viewBookingsHisotryViewModel.ReservationOffers = ReservationOfferDAL.GetReservations(_viewBookingsHisotryViewModel.Client._client);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewBookingsHisotryViewModel.SelectedReservationOffer != null &&
                base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewBookingsHistoryVM.SelectedReservationOffer))
                OnCanExecuteChanged();
        }
    }
}
