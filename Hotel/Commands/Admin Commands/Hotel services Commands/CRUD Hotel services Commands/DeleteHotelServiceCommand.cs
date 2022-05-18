using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Hotel_services_Commands
{
    public class DeleteHotelServiceCommand:BaseCommand
    {
        private readonly AdminMainVM _adminMainVM;
        public DeleteHotelServiceCommand(AdminMainVM adminMainVM)
        {
            _adminMainVM = adminMainVM;
            _adminMainVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            HotelServiceDAL.DeleteHotelService(_adminMainVM.SelectedHotelService._hotelService);
            _adminMainVM.HotelServices.Remove(_adminMainVM.SelectedHotelService);
        }

        public override bool CanExecute(object parameter)
        {
            return _adminMainVM.SelectedHotelService != null && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AdminMainVM.SelectedHotelService))
                OnCanExecuteChanged();
        }
    }
}