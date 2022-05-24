using Hotel.ViewModels;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Client_Commands.Reserve_commands.Hotel_Services
{
    public class AddServiceCommand : BaseCommand
    {
        private readonly MakeBookingVM _makeBookingViewMode;
        public AddServiceCommand(MakeBookingVM makeBookingViewMode)
        {
            _makeBookingViewMode = makeBookingViewMode;
            _makeBookingViewMode.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            HotelServicesVM addedService = _makeBookingViewMode.SelectedService;
            
            //add the service to the reservation items list and remove it from the available list
            _makeBookingViewMode.BookingItems.Add(addedService);
            _makeBookingViewMode.Services.Remove(addedService);
            _makeBookingViewMode.SelectedService = _makeBookingViewMode.Services.FirstOrDefault();

            //update the price of the reservation by adding the price of the added service
            _makeBookingViewMode.BookingVM.TotalPrice += addedService.Price;
        }

        public override bool CanExecute(object parameter)
        {
            return _makeBookingViewMode.SelectedService != null && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeBookingVM.SelectedService))
                OnCanExecuteChanged();
        }
    }
}
