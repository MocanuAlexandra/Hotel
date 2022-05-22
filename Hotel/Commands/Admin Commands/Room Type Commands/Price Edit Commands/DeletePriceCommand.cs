using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Room_Type_Commands.Price_Edit_Commands
{
    public class DeletePriceCommand:BaseCommand
    {
        private readonly PriceEditVM _priceEditViewModel;
        public DeletePriceCommand(PriceEditVM priceEditViewModel)
        {
            _priceEditViewModel = priceEditViewModel;
            _priceEditViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            //delete the price from the view model list, and select the "dummy" price
            //in order to delete the prices from the database when the user clicks save
            //we need to store the prices that already are in the database in a list

            //we know that the price is not in the database if the Id is 0
            if (_priceEditViewModel.SelectedPrice.Id != 0)
            {
                _priceEditViewModel.RoomTypeEditViewModel.PricesToBeDeleted.Add(
                    _priceEditViewModel.SelectedPrice);
            }

            int indexToBeDeleted = _priceEditViewModel.Prices.IndexOf(_priceEditViewModel.SelectedPrice);
            _priceEditViewModel.SelectedPrice = _priceEditViewModel.Prices.FirstOrDefault();
            _priceEditViewModel.Prices.RemoveAt(indexToBeDeleted);
        }

        public override bool CanExecute(object parameter)
        {
            //can delete only if the "dummy" price is not selected, this price
            //is always on position 0
            return _priceEditViewModel.SelectedPrice != _priceEditViewModel.Prices[0]
                && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PriceEditVM.SelectedPrice))
                OnCanExecuteChanged();
        }
    }
}