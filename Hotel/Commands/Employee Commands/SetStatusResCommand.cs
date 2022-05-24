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
    public class SetStatusResCommand : BaseCommand
    {
        private readonly ViewAllBookingsVM _viewAllBookingsViewModel;
        public SetStatusResCommand(ViewAllBookingsVM viewAllBookingsViewModel)
        {
            _viewAllBookingsViewModel = viewAllBookingsViewModel;
            _viewAllBookingsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        //the parameter is the new value of the status
        public override void Execute(object parameter)
        {
            if (parameter is BookingStatus newStatus)
            {
                //change status and update the database
                _viewAllBookingsViewModel.SelectedBooking.Status = newStatus;
                BookingDAL.UpdateBooking(_viewAllBookingsViewModel.SelectedBooking._booking);               
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewAllBookingsViewModel.SelectedBooking != null &&
                base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewAllBookingsVM.SelectedBooking))
                OnCanExecuteChanged();
        }
    }
}
