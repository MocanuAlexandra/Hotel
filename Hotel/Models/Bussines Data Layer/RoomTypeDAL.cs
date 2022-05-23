using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.Bussines_Data_Layer
{
    public static class RoomTypeBLL
    {
        public static float CalculatePriceForTimeInterval(IEnumerable<Price> prices,
            DateTime startDate, DateTime endDate)
        {
            //flag that indicates if prices were found for the entire period
            bool pricedEntirePeriod = false;

            float totalPrice = 0;
            DateTime currentDate = startDate;
            foreach (var price in prices)
            {
                //if the price valability extends past the remaining time period, consider the remaining
                //days included in this price and exit the loop
                if (price.ValabilityStartDate <= currentDate)
                {
                    if (price.ValabilityEndDate >= endDate)
                    {
                        totalPrice += price.Value * (endDate.Subtract(currentDate).Days + 1);
                        pricedEntirePeriod = true;
                        break;
                    }
                    //if the price valability ends before the remaining time period, add the days that 
                    //are covered by the price period and update the remaining time period
                    else
                    {
                        totalPrice += price.Value * (price.ValabilityEndDate.Subtract(currentDate).Days + 1);
                        currentDate = price.ValabilityEndDate.AddDays(1);
                    }
                }
                else
                    break;
            }

            //if prices were not found for the entire period, then the room type can't be reserved, return 0
            if (!pricedEntirePeriod)
                return 0;

            return totalPrice;
        }
    }
}
