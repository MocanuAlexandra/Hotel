using Hotel.ViewModels;
using Hotel.ViewModels.Admin_ViewModels;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.RoomFacilities_Commands
{
    public class OpenEditRoomFacilityWindowCommand : BaseCommand
    {

        private readonly AdminMainVM _adminMainVM;
        public OpenEditRoomFacilityWindowCommand(AdminMainVM adminMainVM)
        {
            _adminMainVM = adminMainVM;
            _adminMainVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            RoomFacilityEditWindow roomTypeEditWindowView = new RoomFacilityEditWindow()
            {
                DataContext = new RoomFacilityEditVM(_adminMainVM,
                RoomFacilityEditVM.RoomFacilityEditMode.Edit)
            };
            roomTypeEditWindowView.ShowDialog();
        }

        public override bool CanExecute(object parameter)
        {
            return _adminMainVM.SelectedFacility != null && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AdminMainVM.SelectedFacility))
                OnCanExecuteChanged();
        }
    }
}

