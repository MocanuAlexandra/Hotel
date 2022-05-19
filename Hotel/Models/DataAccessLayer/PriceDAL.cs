using Hotel.DBContext;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    public static class PriceDAL
    {
        //gets all prices for a certain roomType
        public static ObservableCollection<Price> GetPricesForRoom(int roomTypeId)
        {
            using (var context = new HotelDBContext())
            {
                return new ObservableCollection<Price>(context.Prices.Where(p => p.AssignedRoomTypeId == roomTypeId));
            }
        }

        //given a start and end date, gets the price/prices that fit into
        //that time span for a certain roomType
        public static ObservableCollection<Price> GetPricesInInterval(int roomTypeId,
            DateTime startDate, DateTime endDate)
        {
            using (var context = new HotelDBContext())
            {
                return new ObservableCollection<Price>(context.Prices.Where(
                    p => p.AssignedRoomTypeId == roomTypeId
                && (startDate <= p.ValabilityStartDate
                    && p.ValabilityStartDate <= endDate ||
                    p.ValabilityStartDate <= startDate
                    && startDate <= p.ValabilityEndDate)).OrderBy(p => p.ValabilityStartDate));
            }
        }

        //adds a price to the database


        //given a list of prices, it adds them to the database, or if they already exist, it updates them
        public static void AddOrUpdatePrices(ObservableCollection<Price> prices)
        {
            using (var context = new HotelDBContext())
            {
                foreach (Price price in prices)
                {
                    if (price.Id == 0)
                    {
                        context.Prices.Add(price);
                        context.Entry(price.AssignedRoomType).State = EntityState.Unchanged;
                    }
                    else
                    {
                        var existingPrice = context.Prices.Find(price.Id);
                        context.Entry(existingPrice).CurrentValues.SetValues(price);
                    }
                }
                context.SaveChanges();
            }
        }

        //deletes a price from the database
        public static void DeletePrice(Price price)
        {
            using (var context = new HotelDBContext())
            {
                context.Prices.Attach(price);
                context.Prices.Remove(price);
                context.SaveChanges();
            }
        }
    }
}
