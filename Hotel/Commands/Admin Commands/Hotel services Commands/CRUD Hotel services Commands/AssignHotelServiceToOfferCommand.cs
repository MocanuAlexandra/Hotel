using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels.Admin_View_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Admin_Commands.Hotel_services_Commands.CRUD_Hotel_services_Commands
{
    public class AssignHotelServiceToOfferCommand:BaseCommand
    {
        private readonly AssignHotelServiceToOfferVM _assignHotelServiceVM;

        public AssignHotelServiceToOfferCommand(AssignHotelServiceToOfferVM assignHotelServiceVM)
        {
            _assignHotelServiceVM = assignHotelServiceVM;
            _assignHotelServiceVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            var hotelService = HotelServiceDAL.GetHotelServiceIdByName(_assignHotelServiceVM.SelectedHotelService._hotelService.Name);
            var offer = OfferDAL.GetOfferIdByName(_assignHotelServiceVM.SelectedOffer._offer.Description);

            //verify if the offer already has the hotel service assigned        
            if (HotelServiceDAL.IsHotelServiceAssignedToOffer(hotelService,offer))
            {
                MessageBox.Show("The offer already has the hotel service!", "Error",
                    MessageBoxButton.OK
                   , MessageBoxImage.Error);
                return;
            }

            // assign the hotel service to offer
            HotelServiceDAL.AssignHotelServiceToOffer(hotelService, offer);

            MessageBox.Show("Hotel service assigned successfully!", "Success", MessageBoxButton.OK,
                 MessageBoxImage.Information);

            // after we execute the command, we need to close the window
            _assignHotelServiceVM.CloseWindow();
        }
        public override bool CanExecute(object parameter)
        {
            return _assignHotelServiceVM.SelectedOffer != null
                && _assignHotelServiceVM.SelectedHotelService != null
                && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AssignHotelServiceToOfferVM.SelectedHotelService)
                || e.PropertyName == nameof(AssignHotelServiceToOfferVM.SelectedOffer))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
