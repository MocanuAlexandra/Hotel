using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Employee_Commands
{
    public class SetStatusResOfferCommand : BaseCommand
    {
        private readonly ViewAllBookingsVM _viewAllBookingsViewModel;
        public SetStatusResOfferCommand(ViewAllBookingsVM viewAllBookingsViewModel)
        {
            _viewAllBookingsViewModel = viewAllBookingsViewModel;
            _viewAllBookingsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        //the parameter is the new value of the status
        public override void Execute(object parameter)
        {
            if (parameter is ReservationStatus newStatus)
            {
                //change status and update the database
                _viewAllBookingsViewModel.SelectedReservationOffer.Status = newStatus;
                ReservationOfferDAL.UpdateReservation(_viewAllBookingsViewModel.SelectedReservationOffer._reservationOffer);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewAllBookingsViewModel.SelectedReservationOffer != null &&
                base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewAllBookingsVM.SelectedReservationOffer))
                OnCanExecuteChanged();
        }
    }
}
