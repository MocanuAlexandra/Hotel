using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Room_Facilities_Commands.CRUD_RoomFacilities_Commands
{
    public class DeleteRoomFacilityCommand:BaseCommand
    {
        private readonly AdminMainVM _adminMainVM;
        public DeleteRoomFacilityCommand(AdminMainVM adminMainVM)
        {
            _adminMainVM = adminMainVM;
            _adminMainVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            FacilityDAL.DeleteFacility(_adminMainVM.SelectedFacility._facility);
            _adminMainVM.Facilities.Remove(_adminMainVM.SelectedFacility);
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
