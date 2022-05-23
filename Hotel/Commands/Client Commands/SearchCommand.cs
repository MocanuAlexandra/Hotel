using Hotel.Models.Bussines_Data_Layer;
using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Client_Commands
{
    public class SearchCommand : BaseCommand
    {
        private readonly ClientMainVM _clientViewModel;
        public SearchCommand(ClientMainVM clientViewModel)
        {
            _clientViewModel = clientViewModel;
        }

        public override void Execute(object parameter)
        {          
            //from the database, load the prices for the room types that overlap the input date interval
            foreach (var roomType in _clientViewModel.RoomTypes)
            {
                // get the prices for the room type in the given date interval
                DateTime checkOutDate = _clientViewModel.StartDate.AddDays(_clientViewModel.NoOfNights-1);
                roomType.Prices = PriceDAL.GetPricesInInterval(roomType.Id, _clientViewModel.StartDate,
                    checkOutDate);


                //calculate the total price for the room type in the given time period
                roomType.TotalPriceForPeriod = RoomTypeBLL.CalculatePriceForTimeInterval(roomType.Prices,
                    _clientViewModel.StartDate, checkOutDate);

                //search how many rooms are available for the given time period
                roomType.RoomsOfType.Clear();
                foreach (var room in RoomDAL.GetAvailableRooms(
                    _clientViewModel.StartDate,
                    checkOutDate,
                    roomType._roomType))
                {
                    roomType.RoomsOfType.Add(room);
                }
            }

        }
    }
}

