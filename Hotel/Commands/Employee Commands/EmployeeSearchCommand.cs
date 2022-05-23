using Hotel.Models.Bussines_Data_Layer;
using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Employee_Commands
{
    public class EmployeeSearchCommand : BaseCommand
    {
        private readonly EmployeeMainVM _employeeViewModel;
        public EmployeeSearchCommand(EmployeeMainVM employeeViewModel)
        {
            _employeeViewModel = employeeViewModel;
        }

        public override void Execute(object parameter)
        {
            //from the database, load the prices for the room types that overlap the input date interval
            foreach (var roomType in _employeeViewModel.RoomTypes)
            {
                // get the prices for the room type in the given date interval
                DateTime checkOutDate = _employeeViewModel.StartDate.AddDays(_employeeViewModel.NoOfNights - 1);
                roomType.Prices = PriceDAL.GetPricesInInterval(roomType.Id, _employeeViewModel.StartDate,
                    checkOutDate);


                //calculate the total price for the room type in the given time period
                roomType.TotalPriceForPeriod = RoomTypeBLL.CalculatePriceForTimeInterval(roomType.Prices,
                    _employeeViewModel.StartDate, checkOutDate);

                //search how many rooms are available for the given time period
                roomType.RoomsOfType.Clear();
                foreach (var room in RoomDAL.GetAvailableRooms(
                    _employeeViewModel.StartDate,
                    checkOutDate,
                    roomType._roomType))
                {
                    roomType.RoomsOfType.Add(room);
                }
            }

        }
    }
}

