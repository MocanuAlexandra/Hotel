﻿using Hotel.Models.DataAccessLayer;
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
                roomType.TotalPriceForPeriod = 0;
                DateTime checkInDate = _clientViewModel.StartDate;
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
