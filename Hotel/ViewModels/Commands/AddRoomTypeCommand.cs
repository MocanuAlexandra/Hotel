using Hotel.Models.BusinessLogicLayer;
using Hotel.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Commands
{
    public class AddRoomTypeCommand : BaseCommand
    {
        private AddRoomTypeVM _addRoomTypeVM;

        public AddRoomTypeCommand(AddRoomTypeVM addRoomTypeVM)
        {
            _addRoomTypeVM = addRoomTypeVM;
        }

        public override void Execute(object parameter)
        {
            // first we have to make sure the room type is not already in the database
            if (!RoomTypeDAL.RoomTypeExists(_addRoomTypeVM.InputRoomType))
            {
                // if the room type is not in the database, we can add it
                RoomTypeDAL.AddRoomType(_addRoomTypeVM.InputRoomType, _addRoomTypeVM.InputRoomCapacity);

                // we also need to update the list of room types
                _addRoomTypeVM.AdminStartVM.AddRoomType(_addRoomTypeVM.InputRoomType, _addRoomTypeVM.InputRoomCapacity);
               
                // after adding a rom type, we close the window
                _addRoomTypeVM.CloseWindow();
            }
            else
            {
                _addRoomTypeVM.ErrorMessage = "Room type already exists";
            }
        }
    }
}
