using Hotel.Models.Bussines_Data_Layer;
using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands
{
    public class GuestSearchCommand : BaseCommand
    {
        private readonly GuestWindowVM _guestViewModel;
        public GuestSearchCommand(GuestWindowVM guestViewModel)
        {
            _guestViewModel = guestViewModel;
        }

        public override void Execute(object parameter)
        {
            //from the database, load the prices for the room types that overlap the input date interval
            foreach (var roomType in _guestViewModel.RoomTypes)
            {
                // get the prices for the room type in the given date interval
                DateTime checkOutDate = _guestViewModel.StartDate.AddDays(_guestViewModel.NoOfNights - 1);
                roomType.Prices = PriceDAL.GetPricesInInterval(roomType.Id, _guestViewModel.StartDate,
                    checkOutDate);


                //calculate the total price for the room type in the given time period
                roomType.TotalPriceForPeriod = RoomTypeBLL.CalculatePriceForTimeInterval(roomType.Prices,
                    _guestViewModel.StartDate, checkOutDate);

                //search how many rooms are available for the given time period
                roomType.RoomsOfType.Clear();
                foreach (var room in RoomDAL.GetAvailableRooms(
                    _guestViewModel.StartDate,
                    checkOutDate,
                    roomType._roomType))
                {
                    roomType.RoomsOfType.Add(room);
                }
            }

        }
    }
}
