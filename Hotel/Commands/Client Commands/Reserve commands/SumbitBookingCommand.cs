using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Client_Commands.Reserve_commands
{
    public class SubmitBookingCommand : BaseCommand
    {
        private readonly MakeBookingVM _makeBookingViewModel;
        public SubmitBookingCommand(MakeBookingVM makeBookingViewModel)
        {
            _makeBookingViewModel = makeBookingViewModel;
            _makeBookingViewModel.BookingItems.CollectionChanged += OnReservationItemsChanged;
            _makeBookingViewModel.BookingVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BookingVM.CheckInDate) ||
                (e.PropertyName == nameof(BookingVM.CheckOutDate)))
            {
                OnCanExecuteChanged();
            }
        }

        private void OnReservationItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        public override void Execute(object parameter)
        {
            //first we need to load all the available rooms of the given types
            //and assign them to the reservation, if not enough rooms are available
            //show a message and cancel the saving of the reservation
            List<Room> availableRooms = new List<Room>();
            foreach (var item in _makeBookingViewModel.BookingItems)
            {
                if (item is RoomTypeVM roomTypeVM)
                {
                    var foundRooms = RoomDAL.GetAvailableRooms(
                        _makeBookingViewModel.BookingVM.CheckInDate,
                        _makeBookingViewModel.BookingVM.CheckOutDate.AddDays(-1),
                        roomTypeVM._roomType);

                    if (foundRooms.Count() < roomTypeVM.ItemQuantity)
                    {
                        MessageBox.Show($"Not enough \"{roomTypeVM.Name}\" rooms are available for" +
                            $"the given time period!",
                            "Cannot make reservation",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        return;
                    }

                    availableRooms.AddRange(foundRooms.Skip(foundRooms.Count() -
                        (int)roomTypeVM.ItemQuantity));
                }
                //the item is a service, we just link it to the reservation
                else if (item is HotelServicesVM service)
                    _makeBookingViewModel.BookingVM.HotelServices.Add(service._hotelService);
            }

            //add the rooms to the reservation and save it to the database
            _makeBookingViewModel.BookingVM.Rooms = new ObservableCollection<Room>(availableRooms);
            BookingDAL.AddBooking(_makeBookingViewModel.BookingVM._booking);

            MessageBox.Show("Booking made successfully!", "Success", MessageBoxButton.OK,
                 MessageBoxImage.Information);

            //close the window after the reservation has been made
            _makeBookingViewModel.CloseWindow();
        }

        //can't execute if the reservation doesn't contain at least one room type
        override public bool CanExecute(object parameter)
        {
            return _makeBookingViewModel.BookingItems.Any(item => item is RoomTypeVM)            
                && base.CanExecute(parameter);
        }

    }
}