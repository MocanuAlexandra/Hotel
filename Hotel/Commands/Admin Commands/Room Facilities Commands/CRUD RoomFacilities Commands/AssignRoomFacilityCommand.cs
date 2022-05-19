using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels.Admin_ViewModels;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Admin_Commands.Room_Facilities_Commands.CRUD_RoomFacilities_Commands
{
    public class AssignRoomFacilityCommand:BaseCommand
    {
        private readonly AssignRoomFacilityVM _assignRoomFacilityVM;

        public AssignRoomFacilityCommand(AssignRoomFacilityVM assignRoomFacilityVM)
        {
            _assignRoomFacilityVM = assignRoomFacilityVM;
            _assignRoomFacilityVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            var roomFacility = FacilityDAL.GetFacilityId(_assignRoomFacilityVM.SelectedFacility._facility.Name);
            var roomType = RoomTypeDAL.GetRoomTypeId(_assignRoomFacilityVM.SelectedRoomType._roomType.Name);

            //verify if the room type already has the facility
            if (FacilityDAL.IsFacilityAssignedToRoomType(roomType, roomFacility))
            {
                MessageBox.Show("The room type already has the facility!", "Error",
                    MessageBoxButton.OK
                   , MessageBoxImage.Error);
                return;
            }

            // assign the facility to the room type
            FacilityDAL.AssignFacilityToRoomType(roomFacility, roomType);

            MessageBox.Show("Room facility assigned successfully!", "Success", MessageBoxButton.OK,
                 MessageBoxImage.Information);

            // after we execute the command, we need to close the window
            _assignRoomFacilityVM.CloseWindow();
        }
        public override bool CanExecute(object parameter)
        {
            return _assignRoomFacilityVM.SelectedRoomType != null
                && _assignRoomFacilityVM.SelectedFacility != null
                && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AssignRoomFacilityVM.SelectedRoomType)
                || e.PropertyName == nameof(AssignRoomFacilityVM.SelectedFacility))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
