using Hotel.ViewModels;
using Hotel.ViewModels.Admin_ViewModels;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Hotel_services_Commands
{
    public class OpenEditServiceWindowCommand:BaseCommand
    {
        private readonly AdminMainVM _adminMainVM;
        public OpenEditServiceWindowCommand(AdminMainVM adminMainVM)
        {
            _adminMainVM = adminMainVM;
            _adminMainVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            HotelServiceEditWindow hotelServiceEditWindowView = new HotelServiceEditWindow()
            {
                DataContext = new HotelServiceEditVM(_adminMainVM,
                HotelServiceEditVM.HotelServiceEditMode.Edit)
            };
            hotelServiceEditWindowView.ShowDialog();
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

