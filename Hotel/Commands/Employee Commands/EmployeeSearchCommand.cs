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
                roomType.TotalPriceForPeriod = 0;
                DateTime checkInDate = _employeeViewModel.StartDate;
                foreach (var price in roomType.Prices)
                {
                    //if the price valability extends past the remaining time period, consider the remaining
                    //days included in this price and exit the loop
                    if (price.ValabilityEndDate >= checkOutDate)
                    {
                        roomType.TotalPriceForPeriod +=
                            price.Value * (checkOutDate.Subtract(checkInDate).Days + 1);
                        break;
                    }

                    //if the price valability ends before the remaining time period, add the days that 
                    //are covered by the price period and update the remaining time period
                    else
                    {
                        roomType.TotalPriceForPeriod +=
                            price.Value * (price.ValabilityEndDate.Subtract(checkInDate).Days + 1);
                        checkInDate = price.ValabilityEndDate.AddDays(1);
                    }
                }
            }

        }
    }
}
