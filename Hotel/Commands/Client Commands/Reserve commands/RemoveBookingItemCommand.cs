using Hotel.Utils;
using Hotel.ViewModels;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Client_Commands
{
    public class RemoveBookingItemCommand:BaseCommand
    {
        private readonly MakeBookingVM _makeBookingViewModel;
        public RemoveBookingItemCommand(MakeBookingVM makeBookingViewModel)
        {
            _makeBookingViewModel = makeBookingViewModel;
        }

        //it gets as a parameter the view model of the reservation item that needs to be removed
        public override void Execute(object parameter)
        {
            if (parameter is IBookingItem item)
            {
                _makeBookingViewModel.BookingItems.Remove(item);
                _makeBookingViewModel.BookingVM.TotalPrice -= item.TotalPriceForPeriod;

                //if the parameter is of roomType, add it back to the list of available rooms
                if (parameter is RoomTypeVM rt)
                {
                    _makeBookingViewModel.RoomTypes.Add(rt);
                    if (_makeBookingViewModel.SelectedRoomType == null)
                    {
                        _makeBookingViewModel.SelectedRoomType =
                            _makeBookingViewModel.RoomTypes[0];
                    }
                }
                
                ////else, the parameter is a service, add it to the available services list
                //else if (parameter is HotelServiceVM service)
                //{
                //    _makeReservationViewModel.Services.Add(service);
                //    if (_makeReservationViewModel.SelectedService == null)
                //    {
                //        _makeReservationViewModel.SelectedService =
                //            _makeReservationViewModel.Services[0];
                //    }
                //}
            }
        }
    }
}
