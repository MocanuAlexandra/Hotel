using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels.Admin_ViewModels;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Admin_Commands.Room_Type_Commands.RoomFacilities_Commands
{
    public class SubmitRoomFacilityCommand : BaseCommand
    {
        private readonly RoomFacilityEditVM _roomFacilityEditVM;

        public SubmitRoomFacilityCommand(RoomFacilityEditVM roomFacilityEditViewModel)
        {
            _roomFacilityEditVM = roomFacilityEditViewModel;
        }

        // is executed if the edit window is open in create mode
        private bool ExecuteCreate()
        {
            Facility newFacility = new Facility
            {
                Name = _roomFacilityEditVM.FacilityName,
                IsActive = true
            };

            // add to the list and save to database
            FacilityDAL.AddFacility(newFacility);
            _roomFacilityEditVM.AdminMainVM.Facilities.Add(new FacilityVM(newFacility));

            return true;
        }

        // is executed if the edit window is open in edit mode
        private void ExecuteEdit()
        {
            _roomFacilityEditVM.AdminMainVM.SelectedFacility.Name =
                _roomFacilityEditVM.FacilityName;     
        }

        public override void Execute(object parameter)
        {
            // check if the new room facility name is valid
            if (!Utils.Utility.CheckIfRoomFacilityNameIsValid(_roomFacilityEditVM.FacilityName))
            {
                MessageBox.Show("Facility name is invalid", "Error", MessageBoxButton.OK
                    , MessageBoxImage.Error);
                return;
            }

            // check if window is in create mode
            if (_roomFacilityEditVM.Mode == RoomFacilityEditVM.RoomFacilityEditMode.Add)
            {
                if (ExecuteCreate())
                {
                    _roomFacilityEditVM.CloseWindow();
                }
            }
            else
            {
                ExecuteEdit();
                _roomFacilityEditVM.CloseWindow();
            }
        }
    }
}
