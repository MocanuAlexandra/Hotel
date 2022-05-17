using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.Utils;
using Hotel.ViewModels;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Edit_Room_Type_Commands
{
    public class SubmitRoomTypeCommand : BaseCommand
    {
        private readonly RoomTypeEditVM _roomTypeEditViewModel;

        public SubmitRoomTypeCommand(RoomTypeEditVM roomTypeEditViewModel)
        {
            _roomTypeEditViewModel = roomTypeEditViewModel;
        }

        //is executed if the edit window is open in create mode
        private bool ExecuteCreate(int capacity)
        {
            RoomType newRoomType = new RoomType();

            // first we have to make sure the room type is not already in the database
            if (!RoomTypeDAL.RoomTypeExists(_roomTypeEditViewModel.RoomTypeName))
            {
                newRoomType.Name = _roomTypeEditViewModel.RoomTypeName;
                newRoomType.Capacity = capacity;
                newRoomType.IsActive = true;
                newRoomType.RoomsOfType = new ObservableCollection<Room>();

                //add to the list and database
                RoomTypeDAL.AddRoomType(newRoomType);
                _roomTypeEditViewModel.AdminMainVM.RoomTypes.Add(new RoomTypeVM(newRoomType));

                return true;
            }
            else
            {
                MessageBox.Show("Room type already exists", "Error", MessageBoxButton.OK
                    , MessageBoxImage.Error);
                return false;
            }
        }

        //is executed if the edit window is open in edit mode
        private void ExecuteEdit(int capacity)
        {
            _roomTypeEditViewModel.AdminMainVM.SelectedRoomType.Name =
                _roomTypeEditViewModel.RoomTypeName;
            _roomTypeEditViewModel.AdminMainVM.SelectedRoomType.Capacity = capacity;

            RoomTypeDAL.UpdateRoomType(
                   _roomTypeEditViewModel.AdminMainVM.SelectedRoomType._roomType);
        }

        public override void Execute(object parameter)
        {

            //check if the new room type data is valid and if they are, create the new room type
            //and add it to the list and database
            if (!Utility.CheckIfRoomTypeNameIsValid(_roomTypeEditViewModel.RoomTypeName))
            {
                MessageBox.Show("Room type name is not valid", "Error", MessageBoxButton.OK
                    , MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(_roomTypeEditViewModel.Capacity, out int capacity) || capacity < 1)
            {
                MessageBox.Show("Capacity is not valid", "Error", MessageBoxButton.OK
                    , MessageBoxImage.Error);
                return;
            }

            //check if the window is open in create or edit mode and execute accordingly
            if (_roomTypeEditViewModel.Mode == RoomTypeEditVM.RoomTypeEditMode.Add)
            {
                if (ExecuteCreate(capacity))

                    //close the window
                    _roomTypeEditViewModel.CloseWindow();
            }
            else
            {
                ExecuteEdit(capacity);
                _roomTypeEditViewModel.CloseWindow();
            }

        }
    }
}
