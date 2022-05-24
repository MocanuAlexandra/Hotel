using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Client_Commands.Reserve_commands.Rooms
{
    public class IncreaseNumberOfRooms : BaseCommand
    {
        private readonly RoomTypeVM _roomTypeVM;
        public IncreaseNumberOfRooms(RoomTypeVM roomTypeVM)
        {
            _roomTypeVM = roomTypeVM;
        }

        //the parameter will tell us if we want to increase or decrease the number of rooms
        public override void Execute(object parameter)
        {
            _roomTypeVM.TotalPriceForPeriod += _roomTypeVM.TotalPriceForPeriod / _roomTypeVM.ItemQuantity;
            _roomTypeVM.ItemQuantity++;
        }
    }
}

