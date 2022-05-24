using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Client_Commands.Reserve_commands.Rooms
{
    public class DecreaseNumberOfRooms : BaseCommand
    {
        private readonly RoomTypeVM _roomTypeVM;
        public DecreaseNumberOfRooms(RoomTypeVM roomTypeVM)
        {
            _roomTypeVM = roomTypeVM;
            _roomTypeVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        //the parameter will tell us if we want to increase or decrease the number of rooms
        public override void Execute(object parameter)
        {
            _roomTypeVM.TotalPriceForPeriod -= _roomTypeVM.TotalPriceForPeriod / _roomTypeVM.ItemQuantity;
            _roomTypeVM.ItemQuantity--;
        }
        public override bool CanExecute(object parameter)
        {
            return _roomTypeVM.ItemQuantity > 1 && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RoomTypeVM.ItemQuantity))
                OnCanExecuteChanged();
        }
    }
}