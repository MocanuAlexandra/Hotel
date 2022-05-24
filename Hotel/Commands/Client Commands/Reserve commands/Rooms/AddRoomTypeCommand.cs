using Hotel.Models.Bussines_Data_Layer;
using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Client_Commands
{
    public class AddRoomTypeCommand:BaseCommand
    {
        private readonly MakeBookingVM _makebookingViewModel;
        public AddRoomTypeCommand(MakeBookingVM makeBookingViewModel)
        {
            _makebookingViewModel = makeBookingViewModel;
            _makebookingViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            RoomTypeVM addedRoomType = _makebookingViewModel.SelectedRoomType;
            DateTime startDate = _makebookingViewModel.BookingVM.CheckInDate,
                endDate = _makebookingViewModel.BookingVM.CheckOutDate.AddDays(-1);

            //read the prices from the database
            addedRoomType.Prices = PriceDAL.GetPricesInInterval(addedRoomType.Id, startDate, endDate);

            //add the room type to the items list and remove it from the available room types list
            addedRoomType.ItemQuantity = 1;
            addedRoomType.TotalPriceForPeriod =
                RoomTypeBLL.CalculatePriceForTimeInterval(addedRoomType.Prices, startDate, endDate);
            _makebookingViewModel.BookingItems.Add(_makebookingViewModel.SelectedRoomType);

            _makebookingViewModel.RoomTypes.Remove(addedRoomType);
            _makebookingViewModel.SelectedRoomType = _makebookingViewModel.RoomTypes.FirstOrDefault();

            //update the reservation total price
            _makebookingViewModel.BookingVM.TotalPrice += addedRoomType.TotalPriceForPeriod;

            //when the roomType item quantity changes, we need to update the total reservation price 
            //from the make reservation view model
            addedRoomType.PropertyChanged += _makebookingViewModel.RoomTypeVM_PropertyChanged;
        }

        override public bool CanExecute(object parameter)
        {
            return _makebookingViewModel.SelectedRoomType != null && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeBookingVM.SelectedRoomType))
                OnCanExecuteChanged();
        }
    }
}
